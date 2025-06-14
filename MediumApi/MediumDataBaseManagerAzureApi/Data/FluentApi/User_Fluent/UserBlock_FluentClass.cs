using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.User_Fluent
{
    public class UserBlock_FluentClass : IEntityTypeConfiguration<UserBlockModel>
    {
        public void Configure(EntityTypeBuilder<UserBlockModel> builder)
        {
            // primary Key
            builder.HasKey(b => new { b.UserId, b.BlockedAuthorByUser });
            // Propetries
            // Relationship
            builder.HasOne(b => b.User).WithMany(w => w.BlockedAuthors).HasForeignKey(b => b.UserId);
            // Other Configuration
        }
    }
}
