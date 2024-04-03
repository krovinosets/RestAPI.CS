namespace DatabaseModels;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Image { get; set; }
    
    public string Direction { get; set; }
    
    public string Requirements { get; set; }

    public List<User> Members { get; set; }
    
    public List<Chakaton> Chakatons { get; set; }
    
    public List<Request> Requests { get; set; }

    public int LeaderId { get; set; }

    public User Leader { get; set; }
    //public User User { get; set; } = null!;

    public Team(string name, string image, string direction, string requirements, int leaderId, User user)
    {
        Name = name;
        Image = image;
        Direction = direction;
        Requirements = requirements;
        LeaderId = leaderId;
        Leader = user;
    }
    
    public Team(){}
}