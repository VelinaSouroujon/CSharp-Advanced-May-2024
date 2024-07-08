namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> extensionFiles = new Dictionary<string, List<FileInfo>>();
            DirectoryInfo directoryInfo = new DirectoryInfo(inputFolderPath);
            FileInfo[] filesInfo = directoryInfo.GetFiles();
            StringBuilder filesExtensionsInfo = new StringBuilder();

            foreach (FileInfo file in filesInfo)
            {
                string extension = file.Name.Substring(file.Name.LastIndexOf('.'));

                if(!extensionFiles.ContainsKey(extension))
                {
                    extensionFiles[extension] = new List<FileInfo>();
                }

                extensionFiles[extension].Add(file);
            }

            extensionFiles = extensionFiles
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach(var (extension, fileInfo) in extensionFiles)
            {
                filesExtensionsInfo.AppendLine(extension);

                foreach(FileInfo file in fileInfo.OrderBy(x => x.Length))
                {
                    double size = Math.Round(file.Length / 1024d, 3);
                    filesExtensionsInfo.AppendLine($"--{file.Name} - {size}kb");
                }
            }

            return filesExtensionsInfo.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                            reportFileName;

            File.WriteAllText(path, textContent);
        }
    }
}
