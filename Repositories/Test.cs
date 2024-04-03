using DatabaseContext;
using DatabaseModels;

namespace Repositories;

public class TestRepository
{
    private readonly Database _ctx;
    
    public TestRepository(Database ctx)
    {
        _ctx = ctx;
    }

    public List<Chakaton> GetFisrt()
    {
        return _ctx.Chakatons.ToList();
    }

    public void Insert()
    {
        _ctx.Chakatons.Add(new Chakaton("Test222", 1, "Test", "Test", "Test", "Test"));
        _ctx.SaveChanges();
    }
}