namespace DatabaseModels;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string Organization { get; set; }
    
    public string Post { get; set; }
    
    public string City { get; set; }
    
    public string HardSkills { get; set; }
    
    public string Links { get; set; }
    
    //public Team Team { get; set; }

    public List<Team> Teams { get; set; }

    public User(string name, string email, string password, string organization, 
        string post, string city, string hardSkills, string links)
    {
        Name = name;
        Email = email;
        Password = password;
        Organization = organization;
        Post = post;
        City = city;
        HardSkills = hardSkills;
        Links = links;
    }
    
    public User(){}
}
