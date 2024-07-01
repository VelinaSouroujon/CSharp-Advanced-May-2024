namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using FileStream firstPart = new FileStream(partOneFilePath, FileMode.Create);
            using FileStream secondPart = new FileStream(partTwoFilePath, FileMode.Create);

            byte[] allBytes = File.ReadAllBytes(sourceFilePath);

            int lengthOfFirstBuffer = (int)Math.Ceiling((double)allBytes.Length / 2);
            byte[] buffer1 = allBytes.Take(lengthOfFirstBuffer).ToArray();

            byte[] buffer2 = allBytes.Skip(lengthOfFirstBuffer).ToArray();

            firstPart.Write(buffer1);
            secondPart.Write(buffer2);
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using FileStream writer = new FileStream(joinedFilePath, FileMode.Create);

            byte[] buffer1 = File.ReadAllBytes(partOneFilePath);
            writer.Write(buffer1);

            byte[] buffer2 = File.ReadAllBytes(partTwoFilePath);
            writer.Write(buffer2);
        }
    }
}