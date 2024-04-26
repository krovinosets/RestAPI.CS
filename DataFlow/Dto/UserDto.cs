using System.Text.Json.Serialization;
using DataFlow.Entities;
using DataFlow.Models;

namespace DataFlow.Dto;

public class UserDto : IDto
{
    [JsonIgnore]
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Organization { get; set; }
    public string? Post { get; set; }
    public string? City { get; set; }
    public string? HardSkills { get; set; }
    public string? Links { get; set; }
    [JsonIgnore]
    public List<Team>? Teams { get; set; }

    public IEntity ToEntity()
    {
        UserEntity ue = new UserEntity();
        ue.Id = Id;
        ue.Name = Name;
        ue.Email = Email;
        ue.Password = Password;
        ue.Organization = Organization;
        ue.Post = Post;
        ue.City = City;
        ue.HardSkills = HardSkills;
        ue.Links = Links;
        ue.Teams = Teams;
        return ue;
    }
}