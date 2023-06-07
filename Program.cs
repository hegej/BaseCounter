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
            string binary = Convert.ToString(i, 2).ToUpper(); // Capitalize base 2 representation
            Console.WriteLine($"BASE2  | {i} | {binary}");
            Console.WriteLine($"BASE10 | {i} | {i}");

            if (i <= countToBase)
            {
                string binaryBase16 = Convert.ToString(i, 16).ToUpper(); // Capitalize base 16 representation
                Console.WriteLine($"BASE16 | {i} | {binaryBase16}");
            }

            if (i <= countToBase)
            {
                string binaryBase32 = ConvertToBase32(i).ToUpper(); // Capitalize base 32 representation using custom conversion
                Console.WriteLine($"BASE32 | {i} | {binaryBase32}");
            }

            if (i <= countToBase)
            {
                string binaryBase64 = ConvertToBase64(i).ToUpper(); // Capitalize base 64 representation using custom conversion
                Console.WriteLine($"BASE64 | {i} | {binaryBase64}");
            }

            Thread.Sleep(500);
        }
    }

    static string ConvertToBase32(int number)
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567"; // Base 32 characters
        string result = string.Empty;

        do
        {
            result = characters[number % 32] + result;
            number /= 32;
        } while (number > 0);

        return result;
    }

    static string ConvertToBase64(int number)
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"; // Base 64 characters
        string result = string.Empty;

        do
        {
            result = characters[number % 64] + result;
            number /= 64;
        } while (number > 0);

        return result;
    }
}
