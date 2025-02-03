using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ContentState_Fluent
{
    public class BlockModel_FluentClass : IEntityTypeConfiguration<BlockModel>
    {
        public void Configure(EntityTypeBuilder<BlockModel> builder)
        {
            // primary Key
            builder.HasKey(x => x.Id);
            // Propetries

            // Relationship
            builder.HasOne(b => b.ContentState).WithMany(c => c.blocks).HasForeignKey(b => b.ContentStateId);
            // Other Configuration
        }
    }
}
