namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            HashSet<string> inputBytes = new HashSet<string>(File.ReadAllLines(bytesFilePath));

            using (FileStream stream = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    byte[] buffer = new byte[1024];
                    int readBytes = stream.Read(buffer, 0, buffer.Length);

                    while(readBytes > 0)
                    {
                        foreach (byte b in buffer)
                        {
                            if (inputBytes.Contains(b.ToString()))
                            {
                                writer.WriteLine(b.ToString());
                            }
                        }
                        readBytes = stream.Read(buffer, 0, buffer.Length);
                    }

                }
            }     
        }
    }
}
