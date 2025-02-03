using MediumDataBaseManagerAzureApi.Models.ContentState;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ContentStateWrapper_Fluent
{
    public class ContentStateAboutUserWrapperModel_FluentClass : IEntityTypeConfiguration<ContentStateAboutUserWrapperModel>
    {
        public void Configure(EntityTypeBuilder<ContentStateAboutUserWrapperModel> builder)
        {
            // primary Key
            builder.HasKey(x => x.Id);
            // Propetries
            // Relationship
            builder.HasOne(w => w.User).WithOne(u => u.AboutContent).HasForeignKey<ContentStateAboutUserWrapperModel>(w => w.UserId);
            builder.HasOne(w => w.ContentStateModelAboutUser).WithOne().HasForeignKey<ContentStateAboutUserWrapperModel>(w => w.ContentStateModelAboutUserId);
            // Other Configuration
        }
    }
}
