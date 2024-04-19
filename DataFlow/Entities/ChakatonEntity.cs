using DataFlow.Dto;
using DataFlow.Models;

namespace DataFlow.Entities;

public class ChakatonEntity : IEntity
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public int? Dates { get; set; }
    public string? Type { get; set; }
    public string? Direction { get; set; }
    public string? Info { get; set; }
    public string? Links { get; set; }
    public List<Team>? Teams { get; set; }
    
    public IModel ToModel()
    {
        Chakaton chakaton = new Chakaton();
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

    public IDto ToDto()
    {
        ChakatonDto chakaton = new ChakatonDto();
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