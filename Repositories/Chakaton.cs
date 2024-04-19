using DatabaseContext;
using DataFlow.Entities;
using DataFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class ChakatonRepository
{
    private readonly Database _ctx;
    
    public ChakatonRepository(Database ctx)
    {
        _ctx = ctx;
    }

    private Chakaton GetRecord(Chakaton chakaton)
    {
        if (chakaton.Id == null)
            throw new Exception("Unexpected Nullable");
        
        List<Chakaton> chakatons = _ctx.Chakatons.Where(u => u.Id == chakaton.Id).Include(u => u.Teams).ToList();
        if (chakatons.Count == 0)
            throw new Exception($"Record 'User' with PK_id:{chakaton.Id} not found");
        
        return chakatons.First();
    }
    
    public ChakatonEntity GetId(Chakaton chakaton)
    {
        return (ChakatonEntity) GetRecord(chakaton).ToEntity();
    }
    
    public List<ChakatonEntity> GetAll()
    {
        var lst = _ctx.Chakatons.Include(u => u.Teams).ToList();
        List<ChakatonEntity> chakatonEntities = new List<ChakatonEntity>();
        foreach (var elem in lst)
        {
            ChakatonEntity ue = (ChakatonEntity) elem.ToEntity();
            chakatonEntities.Add(ue);
        }
        return chakatonEntities;
    }
}