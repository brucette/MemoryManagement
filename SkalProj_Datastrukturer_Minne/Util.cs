using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    public static class Util
    {
        public static string GetUserInput(string prompt)
        {
            string answer = "";

            while (true)
            {
                Console.WriteLine($"{prompt}:");
                answer = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                else
                { 
                    return answer;
                }
            }
        }

        public static void PrintWithColour(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
