using System.Diagnostics.CodeAnalysis;

namespace DatabaseModels;

public class Chakaton
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int Dates { get; set; }
    
    public string Type { get; set; }
    
    public string Direction { get; set; }
    
    public string Info { get; set; }
    public string Links { get; set; }
    
    public List<Team> Teams { get; set; }

    public Chakaton(string name, int dates, string type, string direction, 
        string info, string links)
    {
        Name = name;
        Dates = dates;
        Type = type;
        Direction = direction;
        Info = info;
        Links = links;
    }

    public Chakaton()
    {
    }
}