using MediumDataBaseManagerAzureApi.Models.ManyToMany.StoryWrapperManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class StoryToAuthorsConectorModel_FluentClass : IEntityTypeConfiguration<StoryToAuthorsConectorModel>
    {
        public void Configure(EntityTypeBuilder<StoryToAuthorsConectorModel> builder)
        {
        // primary Key
        builder.HasKey(x => x.Id);
        // Propetries
        // Relationship
        builder.HasOne(sa => sa.UserWrapper).WithMany().HasForeignKey(x => x.UserWrapperId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(sa => sa.ContentStateWrapper).WithMany(cs => cs.Authors).HasForeignKey(sa => sa.ContentStateWrapperId).OnDelete(DeleteBehavior.NoAction);




            // Other Configuration
        }
    }
}
