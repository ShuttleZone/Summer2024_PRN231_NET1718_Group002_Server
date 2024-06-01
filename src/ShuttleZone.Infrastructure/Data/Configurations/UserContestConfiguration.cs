using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class UserContestConfiguration : IEntityTypeConfiguration<UserContest>
{
    public void Configure(EntityTypeBuilder<UserContest> builder)
    {
        builder.HasKey(uc =>  new {uc.ContestId, uc.ParticipantsId});

        builder.HasOne(uc => uc.Contest)
            .WithMany(uc => uc.UserContests)
            .HasForeignKey(uc => uc.ContestId);
        
        builder.HasOne(uc => uc.Participant)
            .WithMany(uc => uc.UserContests)
            .HasForeignKey(uc => uc.ParticipantsId);
        
            builder.HasData(new UserContest
        {
            ParticipantsId = Guid.Parse("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
            ContestId = Guid.Parse("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
            isCreatedPerson = true,
            isWinner = false,
            Point = 8
        },
            new UserContest
            {
                ParticipantsId = Guid.Parse("26a7cc4e-3f9b-4923-809e-2f9b771d994f"),
                ContestId = Guid.Parse("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                isCreatedPerson = false,
                isWinner = true,
                Point = 10
            }
        
        );
    }
}