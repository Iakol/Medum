using MediumDataBaseManagerAzureApi.Models.ManyToMany.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ManyToMany
{
    public class ClapsToResponceOfUsers_FluentClass : IEntityTypeConfiguration<ClapsToResponceOfUsers>
    {
        public void Configure(EntityTypeBuilder<ClapsToResponceOfUsers> builder)
        {
            // primary Key
            builder.HasKey(x =>new { x.ResponceId,x.UserId });
            // Propetries
            // Relationship   
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Responce).WithMany(r => r.UserClaps).HasForeignKey(x => x.Responce);

            // Other Configuration
        }
    }
}
