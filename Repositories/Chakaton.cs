using System.Data;
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
            throw new NoNullAllowedException("Unexpected Nullable");
        
        List<Chakaton> chakatons = _ctx.Chakatons.Where(u => u.Id == chakaton.Id).Include(u => u.Teams).ToList();
        if (chakatons.Count == 0)
            throw new KeyNotFoundException($"Record 'User' with PK_id:{chakaton.Id} not found");
        
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
    
    public ChakatonEntity Add(Chakaton chakaton)
    {
        if (chakaton.Name == null ||
            chakaton.Dates == null ||
            chakaton.Type == null ||
            chakaton.Direction == null ||
            chakaton.Info == null ||
            chakaton.Links == null)
            throw new NoNullAllowedException($"chakaton model has a null field");
        
        _ctx.Chakatons.Add(chakaton);
        _ctx.SaveChanges();
        
        return (ChakatonEntity) chakaton.ToEntity();
    }
    
    public ChakatonEntity Update(Chakaton chakaton)
    {
        if (chakaton.Id == null)
            throw new NoNullAllowedException($"chakaton model has a null field");

        Chakaton chakatonDb = GetRecord(chakaton);

        if (chakaton.Name != null) chakatonDb.Name = chakaton.Name;
        if (chakaton.Dates != null) chakatonDb.Dates = chakaton.Dates;
        if (chakaton.Type != null) chakatonDb.Type = chakaton.Type;
        if (chakaton.Direction != null) chakatonDb.Direction = chakaton.Direction;
        if (chakaton.Info != null) chakatonDb.Info = chakaton.Info;
        if (chakaton.Links != null) chakatonDb.Links = chakaton.Links;
        
        _ctx.SaveChanges();
        
        return (ChakatonEntity) chakatonDb.ToEntity();
    }
    
    public ChakatonEntity Remove(Chakaton chakaton)
    {
        Chakaton chakatonDb = GetRecord(chakaton);

        _ctx.Chakatons.Remove(chakatonDb);
        _ctx.SaveChanges();
        
        return (ChakatonEntity) chakatonDb.ToEntity();
    }
}