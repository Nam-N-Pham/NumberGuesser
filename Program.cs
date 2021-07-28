using System;

namespace NumberGuesser
{
    class Program
    {
        static void showGreeting()
        {
            Console.WriteLine("Hi, welcome to Number Guesser. This program will try to guess a number you are thinking of " +
                                "between 1 and 1024 inclusive. Think of a number within the range. The program will guess your number " +
                                "then you will have to say type \"Higher\" if your number is greater than the guess, \"Lower\" if your number " +
                                "is less than the guess, or \"Correct\" if your number is equal to the guess. Type \"Start\" when you are ready.");
        }

        static double CalculateGuess(double minNum, double maxNum)
        {
            return Math.Floor((minNum + maxNum) / 2);
        }

        static void Main(string[] args)
        {
            showGreeting();

            double minNum = 1;
            double maxNum = 1024;

            string start = Console.ReadLine();

            Boolean correctGuess = false;
            string userAnswer;

            while (!correctGuess)
            {
                double currentGuess = CalculateGuess(minNum, maxNum);
                Console.WriteLine($"Is your number {currentGuess}?");
                userAnswer = Console.ReadLine();

                if (userAnswer == "Correct")
                {
                    correctGuess = true;
                    Console.WriteLine("I win! Game over.");
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
    }
}
