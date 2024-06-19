using System;
using System.Collections.Generic;
using System.Text;

namespace _9.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> textStates = new Stack<string>();
            textStates.Push(string.Empty);
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder(textStates.Peek());

            for (int i = 0; i < n; i++)
            {
                string[] inputTokens = Console.ReadLine().Split();
                int command = int.Parse(inputTokens[0]);

                switch (command)
                {
                    case 1:
                        string strToAppend = inputTokens[1];
                        text.Append(strToAppend);
                        textStates.Push(text.ToString());
                        break;

                    case 2:
                        int numberOfElementsToDelete = int.Parse(inputTokens[1]);
                        text.Remove(text.Length - numberOfElementsToDelete, numberOfElementsToDelete);
                        textStates.Push(text.ToString());
                        break;

                    case 3:
                        int index = int.Parse(inputTokens[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;

                    case 4:
                        if (textStates.Count > 0)
                        {
                            textStates.Pop();
                            text.Clear();
                            if(textStates.Count > 0)
                            {
                                text.Append(textStates.Peek());
                            }
                        }
                        break;
                }
            }
        }
    }
}
