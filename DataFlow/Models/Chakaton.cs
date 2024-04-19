using DataFlow.Entities;

namespace DataFlow.Models;

public class Chakaton : IModel
{
    public int? Id { get; set; }
    
    public string? Name { get; set; }
    
    public int? Dates { get; set; }
    
    public string? Type { get; set; }
    
    public string? Direction { get; set; }
    
    public string? Info { get; set; }
    
    public string? Links { get; set; }
    
    public List<Team>? Teams { get; set; }

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

    public Chakaton(){}

    public IEntity ToEntity()
    {
        ChakatonEntity chakaton = new ChakatonEntity();
        chakaton.Id = Id;
        chakaton.Name = Name;
        chakaton.Dates = Dates;
        chakaton.Type = Type;
        chakaton.Direction = Direction;
        chakaton.Info = Info;
        chakaton.Links = Links;
        chakaton.Teams = Teams;
        return chakaton;
    }
}