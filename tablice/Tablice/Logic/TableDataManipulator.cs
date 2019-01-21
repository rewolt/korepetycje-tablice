using System;
using System.Collections.Generic;
using System.Text;

namespace Tablice.Logic
{
    class TableDataManipulator : IDataManipulator
    {
        private readonly string[][] _doctors;


        public TableDataManipulator(string[][] doctors)
        {
            _doctors = doctors;
        }


        public string GetName(int doctorId)
        {
            if (_doctors == null || _doctors.Length == 0 || doctorId < 0 || doctorId > _doctors.GetLength(0))
                throw new ArgumentException("There is no such doctor");

            return _doctors[doctorId][0];
        }

        public int GetSaldo(int doctorId)
        {
            if (_doctors == null || _doctors.Length == 0 || doctorId < 0 || doctorId > _doctors.GetLength(0))
                throw new ArgumentException("There is no such doctor");

            var admittedPatients = int.Parse(_doctors[doctorId][1]);
            var dischargedPatients = int.Parse(_doctors[doctorId][2]);

            return admittedPatients - dischargedPatients;
        }


        public int GetGlobalSaldo()
        {
            var admittedSum = 0;
            var dischargedSum = 0;

            for(int i = 0; _doctors.GetLength(0) > i; i++)
            {
                admittedSum += int.Parse(_doctors[i][1]);
                dischargedSum += int.Parse(_doctors[i][2]);
            }

            return admittedSum - dischargedSum;
        }


        public string GetMostHardworkingDoctor()
        {
            string[] mostHardworkingDoctor = null;
            var maxDischargedPatients = 0;

            for(int i =0; _doctors.GetLength(0) > i; i++)
            {
                var discharged = int.Parse(_doctors[i][2]);
                if (discharged > maxDischargedPatients)
                {
                    mostHardworkingDoctor = _doctors[i];
                    maxDischargedPatients = discharged;
                }
            }

            return mostHardworkingDoctor[0];
        }

        public int GetDoctorsVolume()
        {
            return _doctors.GetLength(0);
        }
    }
}
