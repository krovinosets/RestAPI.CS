using System.Text.Json.Serialization;
using DataFlow.Entities;
using DataFlow.Models;

namespace DataFlow.Dto;

public class ChakatonDto : IDto
{
    [JsonIgnore]
    public int? Id { get; set; }
    public string? Name { get; set; }
    public int? Dates { get; set; }
    public string? Type { get; set; }
    public string? Direction { get; set; }
    public string? Info { get; set; }
    public string? Links { get; set; }
    [JsonIgnore]
    public List<Team>? Teams { get; set; }
    
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