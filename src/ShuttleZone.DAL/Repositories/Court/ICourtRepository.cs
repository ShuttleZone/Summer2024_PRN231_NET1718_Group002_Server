using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.DAL.Repositories.Court;
[AutoRegister]
public interface ICourtRepository : IGenericRepository<Domain.Entities.Court>
{
    
}