using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ContentState_Fluent
{
    public class EntityMapModel_FluentClass : IEntityTypeConfiguration<EntityMapModel>
    {
        public void Configure(EntityTypeBuilder<EntityMapModel> builder)
        {

            // primary Key
            builder.HasKey(e => e.id);
            // Propetries
            // Relationship
            builder.HasOne(e => e.ContentState).WithMany(c => c.entityMap).HasForeignKey(b => b.ContentStateKey);
            // Other Configuration
        }
    }
}
