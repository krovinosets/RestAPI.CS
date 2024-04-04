namespace Services;

public class Services
{
    public readonly TestService TestService;
    
    public Services(Repositories.Repositories repositories)
    {
        TestService = new TestService(repositories);
    }
}