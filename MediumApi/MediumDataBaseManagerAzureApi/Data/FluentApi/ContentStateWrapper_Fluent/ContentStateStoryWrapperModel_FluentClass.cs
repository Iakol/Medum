using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.TopicManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ContentStateWrapper_Fluent
{
    public class ContentStateStoryWrapperModel_FluentClass : IEntityTypeConfiguration<ContentStateStoryWrapperModel>
    {
        public void Configure(EntityTypeBuilder<ContentStateStoryWrapperModel> builder)
        {
            // primary Key
            builder.HasKey(x => x.Id);
            // Propetries
            // Relationship
                //Link To ContentState
            builder.HasOne(x => x.ContentState).WithOne().HasForeignKey<ContentStateStoryWrapperModel>(c => c.Id);
                //Link To Creator
            builder.HasOne(w => w.StoryCreator).WithMany(w => w.UserStories).HasForeignKey(c => c.StoryCreatorId);
                // Link To Topic List
            builder.HasMany(w => w.topics).WithMany(t => t.Stories).UsingEntity<TopicToStoryConectorModel>();
                // Readers List
            builder.HasMany(w => w.ReaderOfStory).WithOne().HasForeignKey(r => r.ReadId);
            //builder.HasMany(w => w.Authors).WithMany().UsingEntity<StoryToAuthorsConectorModel>();

            // Other Configuration
        }
    }
}
