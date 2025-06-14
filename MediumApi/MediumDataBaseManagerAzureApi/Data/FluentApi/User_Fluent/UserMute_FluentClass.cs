using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.User_Fluent
{
    public class UserMute_FluentClass : IEntityTypeConfiguration<UserMuteModel>
    {
        public void Configure(EntityTypeBuilder<UserMuteModel> builder)
        {
            // primary Key
            builder.HasKey(b => new { b.UserId, b.MuteAuthorByUser });
            // Propetries
            // Relationship
            builder.HasOne(b => b.User).WithMany(w => w.MutedAuthors).HasForeignKey(b => b.UserId);
            // Other Configuration
        }
    }
}
