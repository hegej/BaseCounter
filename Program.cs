using System;
using System.Threading;
using Spectre.Console;

class BinaryCounter
{
    static void Main()
    {
        int countToBase = 128;

        var table = new Table { Border = TableBorder.Rounded };
        table.AddColumn("Counter");
        table.AddColumn("Count");
        table.AddColumn("Value");

        for (int i = 0; i <= countToBase; i++)
        {
            Console.Clear(); // Clear the console screen

            table.Rows.Clear(); // Clear the rows from the previous iteration

            string binary = Convert.ToString(i, 2).ToUpper(); // Capitalize base 2 representation
            string base10 = i.ToString();
            string base16 = Convert.ToString(i, 16).ToUpper();
            string base32 = ConvertToBase32(i).ToUpper();
            string base64 = ConvertToBase64(i).ToUpper();

            table.AddRow("BASE2", i.ToString(), binary);
            table.AddRow("BASE10", i.ToString(), base10);
            table.AddRow("BASE16", i.ToString(), base16);
            table.AddRow("BASE32", i.ToString(), base32);
            table.AddRow("BASE64", i.ToString(), base64);

            AnsiConsole.Render(table);

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
