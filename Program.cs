internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Thirty Dollar Tool!");
        Console.WriteLine("Enter path to your file: ");
        string filePath = Console.ReadLine()!;

        string[] inputLines = File.ReadAllLines(filePath);
        string rawLine = "";
        foreach (string inputLine in inputLines)
        {
            rawLine += inputLine;
        }
        string[] items = rawLine.Split('|');

        Console.WriteLine("Old item: ");
        string oldItem = Console.ReadLine()!;
        Console.WriteLine("New item: ");
        string newItem = Console.ReadLine()!;
        Console.WriteLine("Difference: ");
        int difference = Convert.ToInt32(Console.ReadLine()!);

        string outputLine = "";
        for (int i = 0; i < items.Length; i++) 
        {
            string[] itemProp = items[i].Split('@');
            if (itemProp[0] == oldItem)
            {
                itemProp[0] = newItem;
                if (itemProp.Length == 1)
                {
                    itemProp = new string[2]{ itemProp[0], "0" };
                }
                itemProp[1] = Convert.ToString(Convert.ToInt32(itemProp[1]) + difference);
                items[i] = $"{itemProp[0]}@{itemProp[1]}";
            }
            if (itemProp[0] == "!looptarget")
            {
                items[i] = $"\n{itemProp[0]}";
            }
            outputLine += items[i];
            if (i != items.Length - 1)
            {
                outputLine += '|';
            }
            if (itemProp[0] == "!loopmany")
            {
                outputLine += $"\n";
            }
        }

        File.Delete(filePath);
        File.AppendAllText(filePath, outputLine);
    }
}