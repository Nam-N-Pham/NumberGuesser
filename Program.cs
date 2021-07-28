using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        static void showGreeting()
        {
            Console.WriteLine("Hi, welcome to Number Guesser. This program will try to guess a number you are thinking of " +
                                "between 1 and N inclusive, where N is a number you choose. Think of a number within the range. The program will guess your number " +
                                "then you will have to say type \"Higher\" if your number is greater than the guess, \"Lower\" if your number " +
                                "is less than the guess, or \"Correct\" if your number is equal to the guess.");
        }

        static double CalculateGuess(double minNum, double maxNum)
        {
            return Math.Floor((minNum + maxNum) / 2);
        }

        static void Main(string[] args)
        {
            showGreeting();

            List<int> guessesOfEachGame = new List<int>();
            int averageNumGuesses;

            Boolean quit = false;
            while (!quit)
            {
                int numGuesses = 0;

                double minNum = 1;
                Console.Write("Enter a number you want to be the upper limit: ");
                double maxNum = double.Parse(Console.ReadLine());

                double maxNumGuesses = Math.Log2(maxNum) + 1;
                maxNumGuesses = (int)maxNumGuesses;
                Console.WriteLine($"The maximum number of guesses needed is {maxNumGuesses}");

                Boolean correctGuess = false;
                string userAnswer;

                while (!correctGuess)
                {
                    double currentGuess = CalculateGuess(minNum, maxNum);
                    Console.WriteLine($"Is your number {currentGuess}?");
                    numGuesses++;
                    userAnswer = Console.ReadLine();

                    if (userAnswer == "Correct")
                    {
                        correctGuess = true;
                        Console.WriteLine("I win! Game over.");
                        guessesOfEachGame.Add(numGuesses);

                        Console.WriteLine("Would you like to play again? Type \"Yes\" to continue or \"No\" to quit");
                        string replayAnswer = Console.ReadLine();
                        if (replayAnswer == "No")
                        {
                            quit = true;
                        }
                    }
                    else if (userAnswer == "Lower")
                    {
                        maxNum = currentGuess - 1;
                    }
                    else if (userAnswer == "Higher")
                    {
                        minNum = currentGuess + 1;
                    }
                }
            }

            int sum = 0;
            foreach (int guess in guessesOfEachGame)
            {
                sum += guess;
            }
            averageNumGuesses = sum / guessesOfEachGame.Count;
            Console.WriteLine($"The average number of guesses for all the games played is {averageNumGuesses}.");

        }
    }
}
