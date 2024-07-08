namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            HashSet<char> charsToReplace = new HashSet<char> { '-', ',', '.', '!', '?' };
            StringBuilder evenLines = new StringBuilder();
            int counter = 0;
            string line = "";

            while((line = reader.ReadLine()) != null)
            {
                if(counter % 2 == 0)
                {
                    string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    for (int i = words.Length - 1; i >= 0; i--)
                    {
                        string word = words[i];
                        foreach(char c in word)
                        {
                            if(charsToReplace.Contains(c))
                            {
                                evenLines.Append('@');
                            }
                            else
                            {
                                evenLines.Append(c);
                            }
                        }

                        evenLines.Append(' ');
                    }

                    evenLines.AppendLine();
                }
                counter++;
            }
            return evenLines.ToString();
        }
    }
}
