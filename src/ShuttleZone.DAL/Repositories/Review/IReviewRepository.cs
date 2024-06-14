using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;

namespace ShuttleZone.DAL.DependencyInjection.Repositories.Review;
[AutoRegister]
public interface IReviewRepository : IGenericRepository<Domain.Entities.Review>
{
    
}