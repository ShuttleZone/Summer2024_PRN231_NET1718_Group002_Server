// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using ShuttleZone.Domain.Entities;
//
// namespace ShuttleZone.Infrastructure.Data.Configurations;
//
// public class UserContestConfiguration : IEntityTypeConfiguration<UserContest>
// {
//     public void Configure(EntityTypeBuilder<UserContest> builder)
//     {
//         builder.HasKey(uc => uc.UserId);
//         builder.HasKey(uc => uc.ContestId);
//         builder.Property(uc => uc.isCreatedPerson).IsRequired();
//     }
// }