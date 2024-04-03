namespace Services;

public class Services
{
    public readonly TestService TestService;
    
    public Services(Repositories.Repositories repositories)
    {
        Console.WriteLine("Services initialized");
        TestService = new TestService(repositories);
    }
}