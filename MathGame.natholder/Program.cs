/*
requirements:
--------------------------------------
1. You need to create a game that consists of asking the player what's the result of a math question (i.e. 9 x 9 = ?), collecting the input and adding a point in case of a correct answer.
2. A game needs to have at least 5 questions.
3. The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
4. Users should be presented with a menu to choose an operation
5. You should record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.
6. You don't need to record results on a database. Once the program is closed the results will be deleted.
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        Random random = new Random();
        int number;
        bool running = true;
        List<string> history = new List<string>();
        while (running)
        {
            ShowMenu();
            userInput = Console.ReadLine();
            if (int.TryParse(userInput, out number) && number > 0 && number <= 6)
            {
                if (number == 1)
                {
                    history.Add($"Addition Game, score: {PlayGame("+", random)}");
                }
                else if (number == 2)
                {
                    history.Add($"Subtraction Game, score: {PlayGame("-", random)}");
                }
                else if (number == 3)
                {
                    history.Add($"Multiplication Game, score: {PlayGame("*", random)}");
                }
                else if (number == 4)
                {
                    history.Add($"Division Game, score: {PlayGame("/", random)}");
                }
                else if (number == 5)
                {
                    ShowHistory(history);
                }
                else if (number == 6)
                {
                    running = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Welcome! Please make a selection from the options below!");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");
        Console.WriteLine("5. Show History");
        Console.WriteLine("6. Quit");
    }

    static void ShowHistory(List<string> history)
    {
        Console.WriteLine("Game History");

        if (history.Count == 0)
        {
            Console.WriteLine("No game history.");
            return;
        }

        foreach (string game in history)
        {
            Console.WriteLine(game);
        }
    }

    static int PlayGame(string operation, Random random)
    {
        Console.WriteLine("Answer the following question.");
        int score = 0;

        for (int i = 0; i < 5; i++)
        {
            int num1 = random.Next(1, 11);
            int num2 = random.Next(1, 11);
            int userInputInt;
            int solution;
            bool isValidInput;

            switch (operation)
            {
                case "+":
                    solution = num1 + num2;
                    break;

                case "-":
                    solution = num1 - num2;
                    break;

                case "*":
                    solution = num1 * num2;
                    break;

                case "/":
                    num2 = random.Next(1, 11);
                    solution = random.Next(0, 11);
                    num1 = num2 * solution;
                    break;

                default:
                    return -1;
            }

            Console.WriteLine($"{num1} {operation} {num2}");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out userInputInt))
            {
                if (userInputInt == solution)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Wrong!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input! Please enter a number.");
            }
        }
        return score;
    }
}
