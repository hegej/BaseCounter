using System;
using System.Threading;
using Spectre.Console;

class BinaryCounter
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Do you like Spells? (Y/N)");
        ConsoleKeyInfo keyInfo = Console.ReadKey();

        bool drawSpell = (keyInfo.Key == ConsoleKey.Y);

        int countToBase = 128;

        for (int i = 0; i <= countToBase; i++)
        {
            Console.Clear();

            if (drawSpell)
            {
                DrawPulsatingSpell(i);
            }

            var table = new Table { Border = TableBorder.Rounded };
            table.AddColumn("Counter");
            table.AddColumn("Count");
            table.AddColumn("Value");

            string binary = Convert.ToString(i, 2).ToUpper();
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

            if (drawSpell)
            {
                DrawPulsatingSpell(i);
            }

            Console.WriteLine(); 
            Thread.Sleep(500);
        }
    }

    static void DrawPulsatingSpell(int index)
    {
        int width = 27;
        int colorCount = 7;

        double progress = Math.Sin(index * Math.PI / 32); 

        for (int i = 0; i < width; i++)
        {
            int colorIndex = (index + i) % colorCount;
            ConsoleColor color = GetSpellConsoleColor(colorIndex, progress);
            Console.BackgroundColor = color;
            Console.Write(" ");
        }

        Console.ResetColor();
        Console.WriteLine();
    }

    static ConsoleColor GetSpellConsoleColor(int index, double progress)
    {
        double intensity = Math.Max(0, Math.Sin(index * Math.PI / 32 + progress * Math.PI));
        int alpha = (int)(intensity * 255);

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
