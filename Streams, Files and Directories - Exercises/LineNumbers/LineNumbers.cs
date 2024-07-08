namespace LineNumbers
{
    using System;
    using System.Linq;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            int lineNumber = 1;

            foreach (string line in lines)
            {
                int lettersCount = 0;
                int punctuationMarksCount = 0;

                foreach(char c in line)
                {
                    if(Char.IsLetter(c))
                    {
                        lettersCount++;
                    }
                    else if(Char.IsPunctuation(c))
                    {
                        punctuationMarksCount++;
                    }
                }

                File.AppendAllText(outputFilePath, $"Line {lineNumber}: {line} ({lettersCount})({punctuationMarksCount})\n");
                lineNumber++;
            }
        }
    }
}
