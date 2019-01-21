using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tablice.Models;


namespace Tablice.Helpers
{
    class DataReader
    {
        public static int ExpectedFieldsInRow = 3;


        public static string[][] Load_v1(FileInfo[] files)
        {
            var data = new List<string[]>();

            for (var i = 0; files.Length > i; i++)
            {
                var reader = files[i].OpenText();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length != ExpectedFieldsInRow)
                    {
                        Console.WriteLine($"This line cannot be parsed: {line}");
                        continue;
                    }
                    else
                        data.Add(values);
                }
                reader.Dispose();
            }
            return data.ToArray();
        }

        public static List<Doctor> Load_v2(FileInfo[] files)
        {
            var data = new List<Doctor>();

            foreach (var file in files)
            {
                using (var reader = new StreamReader(file.OpenRead()))
                {
                    while(!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length != ExpectedFieldsInRow)
                        {
                            Console.WriteLine($"This line cannot be parsed: {line}");
                            continue;
                        }
                        else
                            data.Add(GetDoctor(values));
                    }
                }
            }

            return data;
        }

        private static Doctor GetDoctor(string[] splitLine)
        {
            var doctor = new Doctor { Name = splitLine[0] };

            int.TryParse(splitLine[1], out int admitted);
            int.TryParse(splitLine[2], out int discharged);

            doctor.AdmittedPatients = admitted;
            doctor.DischargedPatients = discharged;

            return doctor;
        }
    }
}
