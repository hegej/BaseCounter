using System;
using System.Threading;

class BinaryCounter
{
    static void Main()
    {
        int countToBase = 64;


        for (int i = 0; i <= countToBase; i++)
        {
            Console.Clear(); // Clear the console screen
            string binary = Convert.ToString(i, 2);
            Console.WriteLine($"base2  | {i} | {binary}");
            Console.WriteLine($"base10 | {i} | {i}");

            if (i <= countToBase)
            {
                string binaryBase16 = Convert.ToString(i, 16);
                Console.WriteLine($"base16 | {i} | {binaryBase16}");
            }

            Thread.Sleep(500);
        }
    }
}
