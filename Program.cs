using System;
using System.Threading;

class BinaryCounter
{
    static void Main()
    {
        int countTo = 16; // Change this value to set the desired count limit

        for (int i = 0; i <= countTo; i++)
        {
            string binary = Convert.ToString(i, 2);
            Console.WriteLine($"base2  | {i} | {binary}");
            Console.WriteLine($"base10 | {i} | {i}");


            Thread.Sleep(500); 
        }
    }
}

