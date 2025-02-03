using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ContentState_Fluent
{
    public class DictonaryDataInBlockModel_FluentClass : IEntityTypeConfiguration<DictonaryDataInBlockModel>
    {
        public void Configure(EntityTypeBuilder<DictonaryDataInBlockModel> builder)
        {
            // primary Key
            builder.HasKey(x => x.Id);
            // Propetries
            // Relationship
            builder.HasOne(st => st.Block).WithMany(b => b.data).HasForeignKey(st => st.BlockId);

            // Other Configuration
        }
    }
}
