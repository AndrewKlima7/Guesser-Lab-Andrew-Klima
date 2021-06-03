using System;
using System.Collections.Generic;

namespace Guesser_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            while (again == true)
            {


                Random random = new Random();
                int num = random.Next(1, 101);
                Console.WriteLine($"The number to guess is {num}");
                Console.WriteLine();

                Console.WriteLine("Guesser 1");
                int gusser1 = RandomAlg(num);
                Console.WriteLine(gusser1);
                Console.WriteLine();

                Console.WriteLine("Guesser 2");
                int guesser2 = EliminationAlg(num);
                Console.WriteLine(guesser2);
                Console.WriteLine();

                Console.WriteLine("Guesser 3");
                int guesser3 = BruteForce(num);
                Console.WriteLine(guesser3);

                again = GoAgain();
            }
        }

        //best case = 1
        //average = 105
        //worst = infinite
        public static int RandomAlg(int numToGuess)
        {
            int computerGuess = 0;
            int guesses = 0;

            while (computerGuess != numToGuess)
            {
                guesses++;
                Random Guess = new Random();
                computerGuess = Guess.Next(1, 101);

                if(computerGuess > numToGuess || computerGuess < numToGuess)
                {
                    
                }
                else
                {
                    Console.WriteLine($"Guesses = {guesses}");
                    computerGuess = numToGuess;
                }
            }
            return computerGuess;
        }

        //best case = 1
        //average = 50
        //worst = 100
        public static int EliminationAlg(int numToGuess)
        {
            int computerGuess = 0;
            int guesses = 0;
            List<int> exclude = new List<int>(); //this placement is important b/c if in while loop it will not keep the things added to the list just keep creating a new list that is empty
            while (computerGuess != numToGuess)
            {
                //those whole area was really confusing to me
                //basically it says while true give a random num between 1 and 100
                //then if exclude does not contain guess then break that loop;
                //then it does the if statement which adds another int to list exclude
                //then since the list exclude was first stated before the first while loop it keeps
                //the values that were placed in it during the 2nd if statement and then runs it again
                //thus excluding all numbers that was already guessed
                guesses++;
                Random Guess = new Random();
                while (true)
                {
                    computerGuess = Guess.Next(1, 101);
                    if (!exclude.Contains(computerGuess))
                    {
                        break;
                    }
                }
                if (computerGuess > numToGuess || computerGuess < numToGuess)
                {
                    exclude.Add(computerGuess);
                    //Console.WriteLine(computerGuess);
                }
                else
                {
                    Console.WriteLine($"Guesses = {guesses}");
                    computerGuess = numToGuess;
                }
            }
            return computerGuess;
        }

        //best case = 1
        //average = 50
        //worst = 100
        public static int BruteForce(int numToGuess)
        {
            int computerGuess = 0;
            int guesses = 0;
            int decrease = 100;
            while (computerGuess != numToGuess)
            {
                guesses++;
                computerGuess = decrease--;

                if (computerGuess > numToGuess || computerGuess < numToGuess)
                {
                    
                    //Console.WriteLine(computerGuess);
                }
                else
                {
                    Console.WriteLine($"Guesses = {guesses}");
                    computerGuess = numToGuess;
                }
            }
            return computerGuess;
        }

        public static bool GoAgain()
        {
            Console.Write("Would you like to play again? Y/N ");
            string input = Console.ReadLine();

            if (input.ToUpper() == "Y" || input.ToUpper() == "YES")
            {
                Console.WriteLine("");
                Console.WriteLine("");
                return true;
            }
            else if (input.ToUpper() == "N" || input.ToUpper() == "NO")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Must input a valid response.");
                return GoAgain();
            }
        }
    }
}
