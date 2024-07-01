namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            FileInfo[] filesInfo = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
            double totalSize = 0;

            foreach (FileInfo file in filesInfo)
            {
                totalSize += file.Length;
            }
            totalSize = totalSize / 1024;

            File.WriteAllText(outputFilePath, $"{totalSize} KB");
        }
    }
}
