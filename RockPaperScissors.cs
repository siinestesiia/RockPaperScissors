// Rock, Paper and Scissors game.
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

class RockPaperScissors
{
    static void Main(string[] args)
    {
        // Options map
        Dictionary<string, string> optionsMap = new Dictionary<string, string>()
        {
            {"1", "Rock"},
            {"2", "Paper"},
            {"3", "Scissors"}
        };

        GameLoop(optionsMap);
    }

    static void GameLoop(Dictionary<string, string> optionsMap)
    {
        int userScore = 0;
        int computerScore = 0;
        bool hasWon = false;

        // Generate Computer Choice
        Random random = new Random();

        ShowTitle();

        while (!hasWon)
        {
            int computerChoice = random.Next(1, 4); // From 1 to 3.
            ProcessInput(optionsMap, computerChoice, ref userScore, ref computerScore);
            
            if (userScore >= 3)
            {
                Console.WriteLine("You win!");
            }
            else if (computerScore >= 3)
            {
                Console.WriteLine("The Computer wins!");
            }

            if (userScore >= 3 || computerScore >= 3)
            {
                Console.WriteLine("\nDo you want to play again (y/n)?");
                string playAgain = Console.ReadLine() ?? "";

                if (playAgain != "y")
                {
                    Console.WriteLine("Thanks for playing!");
                    hasWon = true;
                }
                else
                {
                    userScore = 0;
                    computerScore = 0;
                }    
            }
        }
    }

    static void ProcessScore(int userChoice, int computerChoice, ref int userScore, ref int computerScore)
    {
        switch (userChoice)
        {
            // User choses Rock
            case 1:
                if (computerChoice == 3)
                {
                    Console.WriteLine("You win! Rock crushes Scissors.");
                    userScore++;
                }
                else if (computerChoice == 2)
                {
                    Console.WriteLine("You lose! Paper covers Rock.");
                    computerScore++;
                }
                else
                {
                    Console.WriteLine("It's a tie! Both chose Rock.");
                }
                break;
            // User choses Paper
            case 2:
                if (computerChoice == 3)
                {
                    Console.WriteLine("You lose! Scissors cuts Paper.");
                    computerScore++;
                }
                else if (computerChoice == 2)
                {
                    Console.WriteLine("It's a tie! Both chose Paper.");
                }
                else
                {
                    Console.WriteLine("You win! Paper covers Rock.");
                    userScore++;
                }
                break;
            // User choses Scissors
            case 3:
                if (computerChoice == 3)
                {
                    Console.WriteLine("It's a tie! Both chose Scissors.");
                }
                else if (computerChoice == 2)
                {
                    Console.WriteLine("You win! Scissors cuts Paper.");
                    userScore++;
                }
                else
                {
                    Console.WriteLine("You lose! Rock crushes Scissors.");
                    computerScore++;
                }
                break;
            default:
                Console.WriteLine("Couldn't compare results..");
                break;
        }

        ShowScore(userScore, computerScore);
    }


    static void ProcessInput(Dictionary<string, string> optionsMap, int computerChoice, ref int userScore, ref int computerScore)
    {
        bool validInput = false;

        while (!validInput)
        {
            ShowOptions(optionsMap);
            
            Console.WriteLine("Choose one of the 3 options by its index: ");
            string userRawInput = Console.ReadLine() ?? "";
            int userChoice;
            
            if (int.TryParse(userRawInput, out userChoice))
            {
                if (userChoice >= 1 && userChoice <= 3)
                {
                    Console.WriteLine($"- You choose: {optionsMap[userRawInput]}.");
                    Console.WriteLine($"- Computer choice: {optionsMap[$"{computerChoice}"]}.");
                    ProcessScore(userChoice, computerChoice, ref userScore, ref computerScore);
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("There are only 3 options..\n");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("You have to enter the number corresponding to one of the 3 options..\n");
                continue;
            }
        }
    }

    static void ShowTitle()
    {
        string title = "-- Rock, Paper and Scissors --";
        Console.WriteLine(title);
    }
 
    static void ShowOptions(Dictionary<string, string> optionsMap)
    {
        Console.WriteLine($"\n1. {optionsMap["1"]}.\n2. {optionsMap["2"]}.\n3. {optionsMap["3"]}.");
    }

    static void ShowScore(int userScore, int computerScore)
    {
        Console.WriteLine(new string('-', 20));
        Console.WriteLine($"User Score: {userScore}.");
        Console.WriteLine($"Computer Score: {computerScore}.");
        Console.WriteLine(new string('-', 20));
    }
 }