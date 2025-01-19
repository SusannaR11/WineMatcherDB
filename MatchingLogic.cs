using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class FoodCategory
{
    //i första menyn väljer man huvudkategori, sen kommer man in i underkategorier
    // som styrs av detta första val
    public static void RunFoodCategory()
    {
        Console.WriteLine("Välj en matkategori: ");
       // Console.WriteLine("1. Kött (nöt, fågel, vilt osv.): ");
       // Console.WriteLine("2. Fisk och skaldjur: ");
        Console.WriteLine("3. Soppa, sallader och kalla förrätter: (VÄLJ NUMMER - 11 - FÖR ATT TESTA)");
        Console.WriteLine("4. Grönsaksbaserade rätter: (VÄLJ NUMMER - 25 - FÖR ATT TESTA)");
       // Console.WriteLine("5. Ostar: ");
      //  Console.WriteLine("6. Dessert och sötsaker: \n");
        string? choice = Console.ReadLine().ToUpper();

         switch (choice)
        {
                case "1":
                    //MeatCategory();  //tbc under utveckling
                    break;
                case "2":
                    //FishCategory(); //tbc under utveckling
                    break;
                case "3":
                    SoupSaladCategory.GetSoupSaladFoodCategory();
                    break;
                case "4":
                    VegetableCategory.GetVegetableFoodCategory();
                    break;
                case "5":
                    //CheeseCategory(); //tbc under utveckling
                    break;
                case "6":
                    //DessertCategory(); //tbc under utveckling
                    break;
                default:
                    break;
            }
            
    }
}
    // Planer att refaktorera och skapa en egen klass för varje underkategori
    // samt se till att logiken separeras för sig.

 /*public class MatchingLogic 
 {
    public static void RunMatchingLogic()
    {
        var repository = new DatabaseRepository();
        using (IDbConnection connection = repository.Connect())
        {
            connection.Open();
        }}}*/
public class SoupSaladCategory
{
    public static void GetSoupSaladFoodCategory()
    {
        var repository = new DatabaseRepository();
        using (IDbConnection connection = repository.Connect())
        {
            connection.Open();

            string sqlQuery = @"
            SELECT f.FoodID, f.Name AS FoodName
            FROM Food f
            WHERE f.Category = 'Salad';";

            try
            {
                var foodCategory = connection.Query(sqlQuery);
                Console.WriteLine("Välj en maträtt (nr.) du vill matcha:");
                    foreach (var row in foodCategory)
                    {
                        Console.WriteLine($"Maträtt nr: {row.FoodID}, Maträtt: {row.FoodName}");
                    }

                    Console.WriteLine("Välj en maträtt (nr.) du vill matcha:");
                    string? choice = Console.ReadLine();

                    if (int.TryParse(choice, out int selectedFoodID))
                    {
                                // Query for matching wine
                            string wineQuery = @"
                            SELECT G.Name, W.Producer
                            FROM Food F
                            JOIN WineToFood WF ON F.FoodID = WF.FoodID
                            JOIN Wine W ON WF.WineID = W.WineID
                            JOIN GrapeToWine GW ON W.WineID = GW.WineID
                            JOIN Grape G ON GW.GrapeID = G.GrapeID
                            WHERE F.FoodID = @FoodID;";

                    
                            string flavourQuery = "SELECT * FROM GetFlavourNamesForFood(@FoodID);";
                            var flavours = connection.Query(flavourQuery, new { FoodID = selectedFoodID });
                            var FlavourNames = string.Join(",", flavours.Select(row => row.FlavourName));
                            Console.WriteLine("Denna maträtt har följande ingredienser och smaker:");
                            foreach (var row in flavours)
                            {
                                Console.WriteLine($"{row.FlavourName}");
                            }
                            //tbc. Här skall 'Notes' från viner hämtas för att visa matchning

                            /*string notesQuery = "SELECT * FROM GetNotesCategoriesForGrape(@GrapeID);";
                            var notes = connection.Query(notesQuery, new { GrapeID = row.GrapeID }).ToList();
                            var NoteNames = string.Join(",", notes.Select(row => row.NotesName));
                            Console.WriteLine("Därför vill man gärna matcha med följande toner i ett vin:");
                            foreach (var row in notes)
                            {
                                Console.WriteLine($"{row.NotesName}");
                            }*/
                            var results = connection.Query(wineQuery, new { FoodID = selectedFoodID });
                            Console.WriteLine("Därför matchar denna maträtt med följande druva: ");
                        
                            foreach (var row in results)
                            {
                                Console.Write($"{row.Name}. \n");
                                Console.WriteLine($"Prova gärna vin från denna producent: {row.Producer}");
                            }
                    }
                    else
                    {             
                        Console.WriteLine("Felaktig inmatning, försök igen.");
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oj det blev fel någonstans. Error: {ex.Message}");
            }
        }
    }
}
public class VegetableCategory
{
    public static void GetVegetableFoodCategory()
    {
        var repository = new DatabaseRepository();
        using (IDbConnection connection = repository.Connect())
        {
            connection.Open();

            string sqlQuery = @"
            SELECT f.FoodID, f.Name AS FoodName
            FROM Food f
            WHERE f.Category = 'Savoury';";

            try
            {
            var foodCategory = connection.Query(sqlQuery, new { FoodCategory = "Savoury" });
            Console.WriteLine("Välj en maträtt (nr.) du vill matcha:");
                foreach (var row in foodCategory)
                {
                    Console.WriteLine($"Maträtt nr: {row.FoodID}, Maträtt: {row.FoodName}");
                }

                Console.WriteLine("Välj en maträtt (nr.) du vill matcha:");
                string? choice = Console.ReadLine().ToUpper();
                if (int.TryParse(choice, out int selectedFoodID))
                {
                    // Query for matching wine
                string wineQuery = @"
                SELECT G.Name, W.Producer
                FROM Food F
                JOIN WineToFood WF ON F.FoodID = WF.FoodID
                JOIN Wine W ON WF.WineID = W.WineID
                JOIN GrapeToWine GW ON W.WineID = GW.WineID
                JOIN Grape G ON GW.GrapeID = G.GrapeID
                WHERE F.FoodID = @FoodID;";

                string flavourQuery = "SELECT * FROM GetFlavourNamesForFood(@FoodID);";
                var flavours = connection.Query(flavourQuery, new { FoodID = selectedFoodID });
                var FlavourNames = string.Join(",", flavours.Select(row => row.FlavourName));
                Console.WriteLine("Denna maträtt har följande ingredienser och smaker:");
                foreach (var row in flavours)
                {
                    Console.WriteLine($"{row.FlavourName}");
                }
                var results = connection.Query(wineQuery, new { FoodID = selectedFoodID });

                Console.Write("Denna maträtt matchar därför med följande druva: ");
                foreach (var row in results)
                {
                    Console.WriteLine($"{row.Name}");
                    Console.WriteLine($"Prova gärna vin från denna producent: {row.Producer} \n");
                }
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning, försök igen.");
                }
            
            
            }
            catch (Exception ex)
            {
                    Console.WriteLine($"Oj det blev fel någonstans. Error: {ex.Message}");
            }
        }
    }
}


