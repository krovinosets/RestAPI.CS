using DatabaseContext;

namespace Repositories;

public class Repositories
{
    public readonly TestRepository TestRepository;
    
    public Repositories(Database database)
    {
        Console.WriteLine("Repositories initialized");
        TestRepository = new TestRepository(database);
    }
}