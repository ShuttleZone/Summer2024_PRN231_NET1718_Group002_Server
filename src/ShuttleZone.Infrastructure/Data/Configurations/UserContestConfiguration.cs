using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class UserContestConfiguration : IDatabaseModelMapper<UserContest>
{
    public void Map(EntityTypeBuilder<UserContest> builder)
    {
        builder.HasKey(uc => uc.UserId);
        builder.HasKey(uc => uc.ContestId);
        builder.Property(uc => uc.isCreatedPerson).IsRequired();
    }
}