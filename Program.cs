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
            FoodCategory.RunFoodCategory();
            break;

            case "2":
            IEnumerable<Wine> wines = repo.GetAllWines();   
            foreach(Wine w in wines)
            {
                Console.WriteLine($"Producer: {w.Producer}, Region: {w.Region}, Vintage: {w.Vintage}");
            }
            break;
        } }

    
}
  