using DatabaseContext;

namespace Repositories;

public class Repositories
{
    public readonly TestRepository TestRepository;
    
    public Repositories(Database database)
    {
        TestRepository = new TestRepository(database);
    }
}