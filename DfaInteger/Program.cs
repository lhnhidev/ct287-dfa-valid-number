namespace DfaInteger.DfaInteger.Main;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter strings to check (press Enter to out):");
        while (true)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (string.IsNullOrEmpty(line)) break;

            if (Integer.TryParse(line, out long num))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  Valid  →  Value = {num}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  Invalid");
            }
            Console.ResetColor();
        }
    }
}