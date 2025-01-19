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
        Console.WriteLine("1. Kött (nöt, fågel, vilt osv.): ");
        Console.WriteLine("2. Fisk och skaldjur: ");
        Console.WriteLine("3. Soppa, sallader och kalla förrätter: ");
        Console.WriteLine("4. Grönsaksbaserade rätter: ");
        Console.WriteLine("5. Ostar: ");
        Console.WriteLine("6. Dessert och sötsaker: \n");
        string? choice = Console.ReadLine().ToUpper();

         switch (choice)
        {
                case "1":
                    //MeatCategory();
                    break;
                case "2":
                    //FishCategory();
                    break;
                case "3":
                    //SoupSaladCategory();
                    break;
                case "4":
                    VegetableCategory.GetVegetableFoodCategory();
                    break;
                case "5":
                    //CheeseCategory();
                    break;
                case "6":
                    //DessertCategory();
                    break;
                default:
                    break;
            }
            
    }
}
        
 /*public class MatchingLogic
 {
    public static void RunMatchingLogic()
    {
        var repository = new DatabaseRepository();
        using (IDbConnection connection = repository.Connect())
        {
            connection.Open();
        }}}*/

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

            var results = connection.Query(wineQuery, new { FoodID = selectedFoodID });

            Console.WriteLine("Denna maträtt matchar med följande druva: ");
            foreach (var row in results)
            {
                Console.WriteLine($"{row.Name}. Prova gärna vin från denna producent: {row.Producer}");
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


