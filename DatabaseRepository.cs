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
      


    