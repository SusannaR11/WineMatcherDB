using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System;


public class Wine
{
    public string? Producer {get; set;}
    public string? Region {get; set;}
    public string? Vintage {get; set;}
}
public class Grape
{
    public string? GrapeName {get; set;}
    public string? GrapeType {get; set;}
    public string? GrapeIntensity {get; set;}
}
public class Notes
{
    public string? NotesName {get; set;}
    public string? NotesType {get; set;}
    public string? NotesIntensity {get; set;}
}
public class GrapeWithNote
{
    public string? GrapeName {get; set;}
    public string? NoteName {get; set;}
    public string? NoteType {get; set;}
    public string? NoteIntensity {get; set;}
}
public class Food
{
    public string? Name {get; set;}
    public string? Category {get; set;}
    public string? Subcategory {get;set;}

}
public class Flavour
{
    public string? FlavourName {get; set;}   
    public string? FlavourType {get; set;}
    public string? FlavourIntensity {get; set;}
}





