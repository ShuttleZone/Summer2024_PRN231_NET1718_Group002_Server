using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.DAL.Repositories;

[AutoRegister]
public interface IContestRepository : IGenericRepository<Contest>
{

}