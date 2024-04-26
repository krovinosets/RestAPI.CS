using DataFlow.Dto;
using DataFlow.Entities;
using DataFlow.Models;

namespace Services;

public class UsersService
{
    private readonly Repositories.Repositories _repositories;
    
    public UsersService(Repositories.Repositories repositories)
    {
        _repositories = repositories;
    }
    
    public UserDto Read(UserEntity user)
    {
        User um = (User) user.ToModel();
        return (UserDto) _repositories.UserRepository.GetId(um).ToDto();
    }
    
    public List<UserDto> ReadAll(UserEntity user)
    {
        User um = (User) user.ToModel();
        var lst = _repositories.UserRepository.GetAll();
        var newlst = new List<UserDto>();
        foreach (var elem in lst)
        {
            UserDto ue = (UserDto) elem.ToDto();
            newlst.Add(ue);
        }
        return newlst;
    }
    
    public UserDto Create(UserEntity user)
    {
        User um = (User) user.ToModel();
        return (UserDto) _repositories.UserRepository.Add(um).ToDto();
    }
    
    public UserDto Update(UserEntity user)
    {
        User um = (User) user.ToModel();
        return (UserDto) _repositories.UserRepository.Update(um).ToDto();
    }
    
    public UserDto Remove(UserEntity user)
    {
        User um = (User) user.ToModel();
        return (UserDto) _repositories.UserRepository.Remove(um).ToDto();
    }
}