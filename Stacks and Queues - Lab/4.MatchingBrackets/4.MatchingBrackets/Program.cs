using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> idxOfOpeningBrackets = new Stack<int>();

            for (int index = 0; index < expression.Length; index++)
            {
                if(expression[index] == '(')
                {
                    idxOfOpeningBrackets.Push(index);
                }
                else if(expression[index] == ')')
                {
                    int openingBracketIdx = idxOfOpeningBrackets.Pop();
                    int closingBracketIdx = index;
                    string subExpression = expression.Substring(openingBracketIdx, closingBracketIdx - openingBracketIdx + 1);
                    Console.WriteLine(subExpression);
                }
            }
        }
    }
}
