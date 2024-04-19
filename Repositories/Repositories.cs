using DatabaseContext;

namespace Repositories;

public class Repositories
{
    public readonly UsersRepository UserRepository;
    public readonly ChakatonRepository ChakatonRepository;
    
    public Repositories(Database database)
    {
        UserRepository = new UsersRepository(database);
        ChakatonRepository = new ChakatonRepository(database);
    }
}