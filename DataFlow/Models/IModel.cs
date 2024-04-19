using DataFlow.Entities;

namespace DataFlow.Models;

public interface IModel
{
    IEntity ToEntity();
}