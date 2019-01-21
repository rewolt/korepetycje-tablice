using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tablice.Helpers
{
    class PathParser
    {
        public string[] Paths { get; set; }
        public FileInfo[] Files { get; private set; }

        public PathParser(string [] filePaths)
        {
            Paths = ParsePaths(filePaths);
            Files = GetTxtFliesInfo(Paths);
        }

        private string[] ParsePaths(string[] paths)
        {
            var validPaths = new List<string>();

            foreach (var path in paths)
            {
                if(Path.IsPathFullyQualified(path))
                {
                    validPaths.Add(path);
                    continue;
                }

                var fullPath = Path.Combine(Environment.CurrentDirectory, path);
                if (!Path.IsPathFullyQualified(fullPath))
                    Console.WriteLine($"Path \"{fullPath}\" is not valid");
                else
                    validPaths.Add(fullPath);
            }

            return validPaths.ToArray();
        }

        private FileInfo[] GetTxtFliesInfo(string[] paths)
        {
            var fileList = new List<FileInfo>();

            foreach (var path in paths)
            {
                var file = new FileInfo(path);

                if (IsTxtFile(file))
                    fileList.Add(file);
                else
                    Console.WriteLine($"File {file.Name} is not a txt file and will not be loaded");
            } 

            return fileList.ToArray();
        }

        private bool IsTxtFile(FileInfo fileInfo)
        {
            return fileInfo.Extension.Equals(".txt", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
