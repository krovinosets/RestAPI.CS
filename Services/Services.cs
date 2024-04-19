namespace Services;

public class Services
{
    public readonly UsersService UsersService;
    public readonly AuthService AuthService;
    public readonly ChakatonService ChakatonService;
    
    public Services(Repositories.Repositories repositories)
    {
        UsersService = new UsersService(repositories);
        AuthService = new AuthService(repositories);
        ChakatonService = new ChakatonService(repositories);
    }
}