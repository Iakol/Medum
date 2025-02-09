using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class ReadingList_UserWrapperToStoryId_FluentClass : IEntityTypeConfiguration<ReadingList_UserWrapperToStoryId>
    {
        public void Configure(EntityTypeBuilder<ReadingList_UserWrapperToStoryId> builder)
        {
        // primary Key
        builder.HasKey(x => x.Id);
        // Propetries
        // Relationship




        //UserStories in Story Wrapper FluentClass

        //User Profile Cred
        // AboutContent in describe in AboutContent FluentClass

        //UUser to Folow


        // Other Configuration
        }
    }
}
