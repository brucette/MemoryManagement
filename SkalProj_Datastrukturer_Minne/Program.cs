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
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
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
         menue.
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
                Console.WriteLine("\nEnter one of the 3 options:" +
                    "\n + Followed by text to add a word to the list, e.g. +Adam" +
                    //"\n\n or " +
                    "\n - Followed by text to remove a word from the list, e.g. -Adam" +
                    "\n 0. Go back to the main menu");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"List Count: {theList.Count}");
                        Console.WriteLine($"List Capacity: {theList.Capacity}");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"List Count: {theList.Count}");
                        Console.WriteLine($"List Capacity: {theList.Capacity}");
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter valid input (starting with + or -)");
                        break;
                }
            }
        }

        // Method for listing out everyone in the queue ???????????????? to helper methods OR UTILS file?
        static void DisplayQueue(Queue<string> queue)
        {
            Console.WriteLine("\nCurrently in queue:");

            foreach (string item in queue)
            {
                Console.WriteLine(item);
            }
        }

        static void ReverseText()
        {
            Console.WriteLine("\nEnter text to be reversed:");
            string text = Console.ReadLine();

            Stack<char> reversedText = new Stack<char>();

            foreach (Char character in text)
                reversedText.Push(character);

            Console.WriteLine("\nReversed text:");
            //foreach (Char character in reversedText)
            //Console.Write(character);

            int stackCount = reversedText.Count;

            for (int i = 0; i < stackCount; i++)
            {
                Console.Write(reversedText.Pop());
            }
            Console.WriteLine();
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

            //icaQueue.Enqueue("Kalle");
            //DisplayQueue(icaQueue);

            //icaQueue.Enqueue("Greta");
            //DisplayQueue(icaQueue);

            //icaQueue.Dequeue();
            //DisplayQueue(icaQueue);

            //icaQueue.Enqueue("Stina");
            //DisplayQueue(icaQueue);

            //icaQueue.Dequeue();
            //DisplayQueue(icaQueue);

            //icaQueue.Enqueue("Olle");
            //DisplayQueue(icaQueue);

            while (true)
            {
                Console.WriteLine("\nEnter one of the 3 options:" +
                   "\n + Followed by name to add customer to queue, e.g. +Greta" +
                   "\n - Serve next customer in the queue" +
                   "\n 0. Go back to the main menu");

                string input = Console.ReadLine();
                char nav = input[0];
                string person = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        icaQueue.Enqueue(person);
                        Console.WriteLine($"\n{person} joined the queue");
                        DisplayQueue(icaQueue);
                        break;
                    case '-':
                        Console.WriteLine($"\n{icaQueue.Dequeue()} was served!");
                        DisplayQueue(icaQueue);
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter valid input (0, 1, 2)");
                        break;
                }
            }
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
                Console.WriteLine("\nSelect one of the 2 options:" +
                   "\n 1. Enter a text to see it reversed" +
                   "\n 0. Go back to the main menu");

                string input = Console.ReadLine();

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

        static bool CheckForValidString(List<Char> list)
        {
            char[] openers = { '(', '{', '[' };
            char[] closers = { ')', '}', ']' };
            bool result = true;

            for (int i = 0; i < list.Count; i++)
            {
                if (closers.Contains(list[i]))
                {
                    //int indexOfPrevious = parenthesis.IndexOf(character) - 1;
                    //char previousCharacter = parenthesis[indexOfPrevious];
                    //parenthesis.RemoveAt(indexOfPrevious);
                    //parenthesis.RemoveAt(indexOfPrevious + 1);

                    char currentCharacter = list[i];
                    char previousCharacter = list[i - 1];

                    bool isPair = CheckIfPair(previousCharacter, currentCharacter);

                    if (isPair)
                    {
                        list.Remove(list[i]);
                        list.Remove(list[i - 1]);
                        Console.WriteLine($"Count: {list.Count}");

                        //Console.WriteLine("List now looks like:");
                        //foreach (Char l in list)
                        //    Console.Write(l);

                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                    //Console.WriteLine(parenthesis.IndexOf(character));
                }
            }
            return result;
        }
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("\nSelect one of the 2 options:" +
                   "\n 1. Enter a text to check its parenthesis" +
                   "\n 0. Go back to the main menu");
            string input = Console.ReadLine();

            char[] valid = { '(', '{', '[', ')', '}', ']' };

            List<Char> parenthesis = new List<Char>();

            switch (input)
            {
                case "1":
                    Console.WriteLine("\nEnter text to be checked:");
                    string text = Console.ReadLine();

                    bool answer = true;

                    // Get only the parenthesis contained in the text entered by user
                    foreach (Char character in text)
                    {
                        if (valid.Contains(character))
                            parenthesis.Add(character);
                    }

                    while (answer != false && parenthesis.Count >= 1)
                    {
                        answer = CheckForValidString(parenthesis);
                    }
                    Console.WriteLine(answer);
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