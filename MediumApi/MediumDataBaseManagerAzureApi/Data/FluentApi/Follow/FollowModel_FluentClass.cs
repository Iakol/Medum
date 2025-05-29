using MediumDataBaseManagerAzureApi.Models.FollowClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.User_Fluent
{
    public class FollowModel_FluentClass : IEntityTypeConfiguration<FollowModel>
    {
        public void Configure(EntityTypeBuilder<FollowModel> builder)
        {
            // primary Key
            builder.HasKey(x => x.Id);
            // Propetries
            // Relationship   
            // Other Configuration
        }
    }
}
