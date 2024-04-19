using DataFlow.Entities;

namespace DataFlow.Models;

public class Request : IModel
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TeamId { get; set; }

    public string RequestText {get; set; }
    
    public User Candidate {get; set; }
    
    public List<Team> Teams { get; set; }
    public Team Team {get; set; }

    public Request(int userId, int teamId, string requestText, User user, Team team)
    {
        UserId = userId;
        TeamId = teamId;
        RequestText = requestText;
        Candidate = user;
        Team = team;
    }
    
    public Request(){}
    
    public IEntity ToEntity()
    {
        throw new NotImplementedException();
    }
}