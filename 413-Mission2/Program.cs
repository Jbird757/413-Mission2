using System;

namespace _413_Mission2
{
    class Program
    {
        static public int RollTwoDice() //Function to roll two dice and return the combined total
        {
            Random rnd = new Random();
            int dieOne = rnd.Next(1, 7);
            int dieTwo = rnd.Next(1, 7);
            int results = dieOne + dieTwo;
            return results;
        }

        static void PrintPercentages(int[] results, int numRolls) //Function to print results
        {
            int counter = 0;
            for (int i = 0; i < results.Length; i++) //Iterates over the results array with counts of each result
            {
                string text = "";
                decimal percentage = (Convert.ToDecimal(results[i]) / Convert.ToDecimal(numRolls)) * 100m; //Converts number of times rolled to percentage
                //Console.WriteLine(results[i] + " / " + numRolls + "* 100 = " + percentage);
                for (int j = 0; j < Convert.ToInt32(percentage); j++)
                {
                    text += "*";
                    counter++;
                }
                Console.WriteLine((i + 2) + ": " + text);
            }
        }
        static void Main(string[] args)
        { 
            //Intro
            Console.WriteLine("Welcome to the dice simulator!");
            Console.Write("How many dice rolls would you like to simulate? ");
            int numRolls = Convert.ToInt32(Console.ReadLine());
            int[] results = new int[11];

            //Roll dice
            for (int i = 0; i < numRolls; i++)
            {
                int result = RollTwoDice();
                //Array has indicies 0-10 and possible results are 2-12. Results are shifted two indicies so index 0 of array holds counts
                //for rolling a 2, index 1 holds counts for 3, etc.
                results[result - 2]++;
            }

            //Results
            Console.Write("\nDICE ROLLING SIMULATION RESULTS\nEach \"*\" " +
                "represents 1% of the total number of rolls.\n");
            Console.WriteLine("Total number of rolls = " + numRolls);

            PrintPercentages(results, numRolls);

            Console.Write("\nThank you for using the dice throwing simulator.\n");
        }
    }
}
