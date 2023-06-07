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
            sting binary = Convert.ToString(i, 2).ToUpper(); // Capitalize base 2 representation
            Console.WriteLine($"BASE2  | {i} | {binary}");
            Console.WriteLine($"BASE10 | {i} | {i}");

            if (i <= countToBase)
            {
                string binaryBase16 = Convert.ToString(i, 16).ToUpper(); // Capitalize base 16 representation
                Console.WriteLine($"BASE16 | {i} | {binaryBase16}");
            }

            if (i <= countToBase)
            {
                string binaryBase32 = Convert.ToString(i, 32).ToUpper(); // Capitalize base 32 representation
                Console.WriteLine($"BASE32 | {i} | {binaryBase32}");
            }

            Thread.Sleep(500);
        }
    }
}
