using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

class MatchingLogic
{
    //i första menyn väljer man huvudkategori, sen kommer man in i underkategorier
    // som styrs av detta första val
    public static void RunMatchingLogic()
    {
        Console.WriteLine("Välj en matkategori: ");
        Console.WriteLine("1. Kött (nöt, fågel, vilt osv.): ");
        Console.WriteLine("2. Fisk och skaldjur: ");
        Console.WriteLine("3. Soppa, sallader och kalla förrätter: ");
        Console.WriteLine("4. Grönsaker: "); //betyder ej vegetariskt
        Console.WriteLine("5. Ostar: ");
        Console.WriteLine("6. Dessert och sötsaker: ");

        
        var repository = new DatabaseRepository();
        using (IDbConnection connection = repository.Connect())
        {
            connection.Open();

// Query för att matcha viner baserat på food category och wine typ (red/white/sparkling)
            string sql = @"
                SELECT DISTINCT Wine.Producer 
                FROM Wine
                INNER JOIN FoodToWine ON Wine.WineID = FoodToWine.WineID
                INNER JOIN Food ON FoodToWine.FoodID = Food.FoodID
                WHERE Food.Category = @FoodCategory
                AND Wine.Type = @WineType";

            var matchedWines = connection.Query<string>(sql, new { 
                FoodCategory = "Savoury", 
                WineType = "Red" 
            });

            Console.WriteLine("Matchande viner: ");
            foreach (var wine in matchedWines)
            {
                Console.WriteLine(wine);
            }
        }
    }}