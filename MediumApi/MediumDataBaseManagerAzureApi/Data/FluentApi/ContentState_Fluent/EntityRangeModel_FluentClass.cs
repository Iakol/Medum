using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ContentState_Fluent
{
    public class EntityRangeModel_FluentClass : IEntityTypeConfiguration<EntityRangeModel>
    {
        public void Configure(EntityTypeBuilder<EntityRangeModel> builder)
        {
            // primary Key
            builder.HasKey(e => e.Id);
            // Propetries
            // Relationship
            builder.HasOne(st => st.Block).WithMany(b => b.entityRanges).HasForeignKey(st => st.Id);
            // Other Configuration
        }
    }
}
