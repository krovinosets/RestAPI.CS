using DataFlow.Dto;
using DataFlow.Entities;
using DataFlow.Models;

namespace Services;

public class ChakatonService
{
    private readonly Repositories.Repositories _repositories;
    
    public ChakatonService(Repositories.Repositories repositories)
    {
        _repositories = repositories;
    }
    
    public ChakatonDto Read(ChakatonEntity chakaton)
    {
        Chakaton um = (Chakaton) chakaton.ToModel();
        return (ChakatonDto) _repositories.ChakatonRepository.GetId(um).ToDto();
    }
    
    public List<ChakatonDto> ReadAll(ChakatonEntity chakaton)
    {
        Chakaton um = (Chakaton) chakaton.ToModel();
        var lst = _repositories.ChakatonRepository.GetAll();
        var newlst = new List<ChakatonDto>();
        foreach (var elem in lst)
        {
            ChakatonDto ue = (ChakatonDto) elem.ToDto();
            newlst.Add(ue);
        }
        return newlst;
    }
}