using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System;


public class Wine
{
    public string Producer {get; set;}
    public string Region {get; set;}
    public string Vintage {get; set;}
}
public class Food
{
    public string Name {get; set;}
    public string Category {get; set;}
    public string Subcategory {get;set;}
    public string Flavours {get; set;}

}



/*
public List<Wine> GetWines()
    {
        string sql = "SELECT Producer, Region, Vintage FROM Wine";
        using IDbConnection conn = Connect();
        return conn.Query<Wine>(sql).AsList();
    }

    */

