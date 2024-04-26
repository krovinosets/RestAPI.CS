using DatabaseContext;
using DataFlow.Entities;
using DataFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class UsersRepository
{
    private readonly Database _ctx;
    
    public UsersRepository(Database ctx)
    {
        _ctx = ctx;
    }

    private User GetRecord(User user)
    {
        if (user.Id == null)
            throw new Exception("Unexpected Nullable");
        
        List<User> users = _ctx.Users.Where(u => u.Id == user.Id).Include(u => u.Teams).ToList();
        if (users.Count == 0)
            throw new Exception($"Record 'User' with PK_id:{user.Id} not found");
        
        return users.First();
    }
    
    public UserEntity GetId(User user)
    {
        return (UserEntity) GetRecord(user).ToEntity();
    }
    
    public UserEntity GetEmail(User user)
    {
        if (user.Email == null)
            throw new Exception("Unexpected Nullable");
        
        List<User> users = _ctx.Users.Where(u => u.Email == user.Email).Include(u => u.Teams).ToList();
        if (users.Count == 0)
            throw new Exception($"Record 'User' with PK_id:{user.Id} not found");
        
        return (UserEntity) users.First().ToEntity();
    }
    
    public List<UserEntity> GetAll()
    {
        var lst = _ctx.Users.Include(u => u.Teams).ToList();
        List<UserEntity> userEntities = new List<UserEntity>();
        foreach (var elem in lst)
        {
            UserEntity ue = (UserEntity) elem.ToEntity();
            userEntities.Add(ue);
        }
        return userEntities;
    }
    
    public UserEntity Add(User user)
    {
        if (user.Id == null ||
        user.Name == null ||
        user.Email == null ||
        user.Password == null ||
        user.Organization == null ||
        user.Post == null ||
        user.City == null ||
        user.HardSkills == null ||
        user.Links == null)
            throw new Exception("Unexpected Nullable");
        
        _ctx.Users.Add(user);
        _ctx.SaveChanges();
        
        return (UserEntity) user.ToEntity();
    }
    
    public UserEntity Update(User user)
    {
        if (user.Id == null)
            throw new Exception("Unexpected Nullable");

        User userDb = GetRecord(user);

        if (user.Name != null) userDb.Name = user.Name;
        if (user.Email != null) userDb.Email = user.Email;
        if (user.Password != null) userDb.Password = user.Password;
        if (user.Organization != null) userDb.Organization = user.Organization;
        if (user.Post != null) userDb.Post = user.Post;
        if (user.City != null) userDb.City = user.City;
        if (user.HardSkills != null) userDb.HardSkills = user.HardSkills;
        if (user.Links != null) userDb.Name = user.Links;
        
        _ctx.SaveChanges();
        
        return (UserEntity) userDb.ToEntity();
    }

    public UserEntity Remove(User user)
    {
        User userDb = GetRecord(user);

        _ctx.Users.Remove(userDb);
        _ctx.SaveChanges();
        
        return (UserEntity) userDb.ToEntity();
    }
}