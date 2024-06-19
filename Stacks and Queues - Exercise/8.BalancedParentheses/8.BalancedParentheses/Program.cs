using System;
using System.Collections.Generic;

namespace _8.BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> parentheses = new Stack<char>();
            string expression = Console.ReadLine();
            bool isBalanced = true;

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (IsOpenParenthesis(c))
                {
                    parentheses.Push(c);
                }
                else if (IsClosingParenthesis(c))
                {
                    if((parentheses.Count == 0) || (parentheses.Peek() != MatchingParenthesis(c)))
                    {
                        isBalanced = false;
                        break;
                    }
                    
                    parentheses.Pop();
                }
            }
            if (parentheses.Count != 0)
            {
                isBalanced = false;
            }

            if(isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        static bool IsOpenParenthesis(char p)
        {
            return p == '(' || p == '[' || p == '{';
        }
        static bool IsClosingParenthesis(char p)
        {
            return p == ')' || p == ']' || p == '}';
        }
        static char MatchingParenthesis(char p)
        {
            if (p == ')')
            {
                return '(';
            }
            else if (p == ']')
            {
                return '[';
            }
            else if (p == '}')
            {
                return '{';
            }
            return '\0';
        }
    }
}
