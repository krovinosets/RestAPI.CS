using DataFlow.Dto;
using DataFlow.Models;

namespace DataFlow.Entities;

public interface IEntity
{
    IModel ToModel();
    IDto ToDto();
}