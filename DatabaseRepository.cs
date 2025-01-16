using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.IO;

class DatabaseRepository
{
    public IDbConnection Connect()
    {
        string connectionString = File.ReadAllText("connectionString.txt").Trim();
        return new SqlConnection(connectionString);
    }

      public List<Wine> GetAllWines()
    {
        string sql = "SELECT Producer, Region, Vintage FROM Wine";
        using IDbConnection conn = Connect();
        return conn.Query<Wine>(sql).AsList();
    }
          
}
      
      /*  IEnumerable<Wine> wines = connection.Query<Wine>("SELECT * FROM Wine");
        IEnumerable<Food>foods = connection.Query<Food>("SELECT Name FROM Food");

        foreach(Wine w in wines)
        {
            Console.WriteLine($"Producer: {w.Producer}, Region: {w.Region}, Vintage: {w.Vintage}");
        }

        foreach (Food f in foods)
        {
            Console.WriteLine($"Dish: {f.Name} has the flavours....");
        }*/


    