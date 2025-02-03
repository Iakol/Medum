using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ContentState_Fluent
{
    public class InlineStylesRangeModel_FluentClass : IEntityTypeConfiguration<InlineStylesRangeModel>
    {
        public void Configure(EntityTypeBuilder<InlineStylesRangeModel> builder)
        {
            // primary Key
            builder.HasKey(x => x.Id);
            // Propetries
            // Relationship
            builder.HasOne(st => st.Block).WithMany(b => b.inlineStyleRanges).HasForeignKey(st => st.BlockId);
            // Other Configuration        
        }
    }
}
