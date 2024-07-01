namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] searchedWords = File.ReadAllText(wordsFilePath)
                                       .ToLower()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in searchedWords)
            {
                wordsCount.Add(word, 0);
            }

            using (StreamReader reader = new StreamReader(textFilePath))
            {
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line
                        .Split(new char[] { ' ', '-', ',', ';', ':', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim().ToLower())
                        .ToArray();

                    foreach (string word in words)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            wordsCount[word]++;
                        }
                    }
                }

                wordsCount = wordsCount
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var (word, count) in wordsCount)
                    {
                        writer.WriteLine($"{word} - {count}");
                    }
                }
            }
        }
    }
}
