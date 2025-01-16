using System.Collections;

class Program
{
    static void Main()
    {
        DatabaseRepository repo = new DatabaseRepository();

        Console.WriteLine("Välj vad du vill matcha - mat eller vin:\n");
        Console.WriteLine("Tryck 1. För att välja maträtt:");
        Console.WriteLine("Tryck 2. För att välja vin:\n");
        string? choice = Console.ReadLine().ToUpper();

        switch (choice)
        {
            case "1":
            MatchingLogic.RunMatchingLogic();
            break;

            case "2":
            IEnumerable<Wine> wines = repo.GetAllWines();

            foreach(Wine w in wines)
            {
                Console.WriteLine($"Producer: {w.Producer}, Region: {w.Region}, Vintage: {w.Vintage}");
            }
            //metod för att hämta röd/vit/bubbel och sen druva 
            //(multiple choice eller läsa och känna igen druva?? av type if contains %cabernet%)
            // också i DB - grape-tabell att länk till viner
            break;

        }




    }
}