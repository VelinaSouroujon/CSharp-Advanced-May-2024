namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using(StreamReader reader1 = new StreamReader(firstInputFilePath))
            {
                using(StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        string line1, line2;

                        while(true)
                        {
                            line1 = reader1.ReadLine();
                            line2 = reader2.ReadLine();

                            if(line1 == null)
                            {
                                if (line2 != null)
                                {
                                    writer.WriteLine(line2);
                                    WriteTheLinesLeft(reader2, writer);
                                }
                                break;
                            }
                            if (line2 == null)
                            {
                                if (line1 != null)
                                {
                                    writer.WriteLine(line1);
                                    WriteTheLinesLeft(reader1, writer);
                                }
                                break;
                            }

                            writer.WriteLine(line1);
                            writer.WriteLine(line2);
                        }                     
                    }
                }
            }
        }
        public static void WriteTheLinesLeft(StreamReader reader, StreamWriter writer)
        {
            string line = "";

            while((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }
        }
    }
}
