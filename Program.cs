namespace bank
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<bank_account> accs = new List<bank_account>();
                while (true)
                {
                    Console.Clear();
                    if (accs.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Doesn't have accs.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("Enter name of acc");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter sum on acc");
                    float sum = float.Parse(Console.ReadLine());
                    bank_account acc = new bank_account(name, sum);
                    acc.input();
                }
            }
            catch
            {
                Console.WriteLine("Something wrong");
            }
        }
    }
}