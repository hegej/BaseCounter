using System;
using System.Threading;
using Spectre.Console;

class BinaryCounter
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Do you like Rainbows? (Y/N)");
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        bool drawRainbow = (keyInfo.Key == ConsoleKey.Y);

        int countToBase = 128;

        for (int i = 0; i <= countToBase; i++)
        {
            Console.Clear(); // Clear the console screen

            if (drawRainbow)
            {
                DrawRainbow(i); // Draw the rainbow effect
            }

            var table = new Table { Border = TableBorder.Rounded };
            table.AddColumn("Counter");
            table.AddColumn("Count");
            table.AddColumn("Value");

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

            Console.WriteLine();
            AnsiConsole.Render(table);

            if (drawRainbow)
            {
                DrawRainbow(i); // Draw the rainbow effect
            }

            Thread.Sleep(500);
        }
    }

    static void DrawRainbow(int index)
    {
        int width = 27;
        int colorCount = 7; // Number of colors in the rainbow

        for (int i = 0; i < width; i++)
        {
            int colorIndex = (index + i) % colorCount;
            ConsoleColor color = GetRainbowConsoleColor(colorIndex);
            Console.BackgroundColor = color;
            Console.Write(" ");
        }

        Console.ResetColor();
    }

    static ConsoleColor GetRainbowConsoleColor(int index)
    {
        return index switch
        {
            0 => ConsoleColor.Red,
            1 => ConsoleColor.DarkYellow,
            2 => ConsoleColor.Yellow,
            3 => ConsoleColor.Green,
            4 => ConsoleColor.Blue,
            5 => ConsoleColor.DarkMagenta,
            _ => ConsoleColor.Magenta
        };
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
