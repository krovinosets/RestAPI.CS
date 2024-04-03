using DatabaseModels;

namespace Services;

public class TestService
{
    private readonly Repositories.Repositories _repositories;
    
    public TestService(Repositories.Repositories repositories)
    {
        _repositories = repositories;
    }

    public List<Chakaton> TestFull()
    {
        _repositories.TestRepository.Insert();
        return _repositories.TestRepository.GetFisrt();
    }
}