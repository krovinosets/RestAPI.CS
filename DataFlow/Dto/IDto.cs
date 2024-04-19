using DataFlow.Entities;

namespace DataFlow.Dto;

public interface IDto
{
    IEntity ToEntity();
    
}