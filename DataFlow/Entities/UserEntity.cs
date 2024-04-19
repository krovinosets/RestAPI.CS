using DataFlow.Dto;
using DataFlow.Models;

namespace DataFlow.Entities;

public class UserEntity : IEntity
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Organization { get; set; }
    public string? Post { get; set; }
    public string? City { get; set; }
    public string? HardSkills { get; set; }
    public string? Links { get; set; }
    public List<Team>? Teams { get; set; }
    
    public IModel ToModel()
    {
        User user = new User();
        user.Id = Id;
        user.Name = Name;
        user.Email = Email;
        user.Password = Password;
        user.Organization = Organization;
        user.Post = Post;
        user.City = City;
        user.HardSkills = HardSkills;
        user.Links = Links;
        user.Teams = Teams;
        return user;
    }

    public IDto ToDto()
    {
        UserDto ue = new UserDto();
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