using System;
using System.Security.Cryptography.X509Certificates;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nPlease navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list    * Loop this method untill the user inputs something to exit to main 
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();

            while (true)
            {
                string input = Util.GetUserInput("\nEnter one of the 3 options:" +
                    "\n + Followed by text to add to the list, e.g. +Adam" +
                    "\n - Followed by text to remove from the list, e.g. -Adam" +
                    "\n 0. Go back to the main menu");
                 
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"\nList Count: {theList.Count}");
                        Console.WriteLine($"List Capacity: {theList.Capacity}\n");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"\nList Count: {theList.Count}");
                        Console.WriteLine($"List Capacity: {theList.Capacity}\n");
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter valid input (starting with +, - or 0)");
                        break;
                }
            }
        }

        static void DisplayQueue(Queue<string> queue)
        {
            if (queue.Count > 0)
            {
                Console.WriteLine("\nCurrently in queue:");

                foreach (string item in queue)
                {
                    Util.PrintWithColour(item, ConsoleColor.DarkRed);
                }
            }
            else
                Console.WriteLine($"\nThe queue is empty!");
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> icaQueue = new Queue<string>();

            while (true)
            {
                string input = Util.GetUserInput("\nEnter one of the 3 options:" +
                   "\n + Followed by name to add customer to queue, e.g. +Greta" +
                   "\n - Serve next customer in the queue" +
                   "\n 0. Go back to the main menu");

                char nav = input[0];
                string person = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        icaQueue.Enqueue(person);
                        Util.PrintWithColour($"\n**{person} joined the queue**", ConsoleColor.Cyan);
                        DisplayQueue(icaQueue);
                        break;
                    case '-':
                        if (icaQueue.Count > 0)
                        {
                            Util.PrintWithColour($"\n{icaQueue.Dequeue()} was served!",         ConsoleColor.Green);
                        }
                        DisplayQueue(icaQueue);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter valid input (+, -, 0)");
                        break;
                }
            }
        }

        static void ReverseText()
        {
            string text = Util.GetUserInput("\nEnter text to be reversed:");

            Stack<char> reversedText = new Stack<char>();

            foreach (Char character in text)
                reversedText.Push(character);

            Console.WriteLine("\nReversed text:");

            int stackCount = reversedText.Count;

            for (int i = 0; i < stackCount; i++)
            {
                Console.Write(reversedText.Pop());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack() 
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            while (true)
            {
                string input = Util.GetUserInput("\nSelect one of the 2 options:" +
                   "\n 1. Enter a text to see it reversed" +
                   "\n 0. Go back to the main menu");

                switch (input)
                {
                    case "1":
                        ReverseText();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Please enter valid input (0, 1)");
                        break;
                }
            }
        }

        static bool CheckIfPair(char a, char b)
        {
            bool result;

            if (a == '(')
                result = b == ')';
            else if (a == '{')
                result = b == '}';
            else
                result = b == ']';

            return result;
        }
        
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            string input = Util.GetUserInput("\nSelect one of the 2 options:" +
                   "\n 1. Enter a text to check its parenthesis" +
                   "\n 0. Go back to the main menu");

            int count = 0;
            char[] openers = { '(', '{', '[' };
            char[] closers = { ')', '}', ']' };
            bool answer = true;
            string message;

            Stack<Char> parenthesis = new Stack<Char>();

            switch (input) 
            {
                case "1":
                    string text = Util.GetUserInput("\nEnter text to be checked:");

                    foreach (Char character in text)
                    {
                        if (openers.Contains(character))
                        {
                            parenthesis.Push(character);
                        }
                        else if (closers.Contains(character) && parenthesis.Count > 0)
                        {
                            // get latest opener parenthesis on the stack
                            char latestOpener = parenthesis.Peek();
                            
                            bool isPair = CheckIfPair(latestOpener, character);

                            if (isPair)
                            {
                                // remove the latest opener from the stack to get the    
                                // next opener, for which we continue looking for a closer, to the top of the stack
                                parenthesis.Pop();
                                count += 1;
                            }
                            else
                            {
                                answer = false;
                                break;
                            }
                        }
                    }

                    // a count of 0 means no pairs have been removed and no parenthesis where in the given input, as a mismatched pair would immediately break the loop
                    // stack should not have elements at the end of the loop as they all should be closed and removed
                    if (count == 0 || parenthesis.Count > 0)
                        answer = false;

                    message = answer ? "Valid string" : "Invalid string";
                    Console.WriteLine($"{message}");
                    break;
                case "0":
                return;
                default:
                    Console.WriteLine("Please enter valid input (0, 1)");
                    break;
            }
        }
    }
}