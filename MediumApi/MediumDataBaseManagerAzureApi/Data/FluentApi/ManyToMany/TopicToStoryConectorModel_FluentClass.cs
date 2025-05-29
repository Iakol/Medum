using MediumDataBaseManagerAzureApi.Models.ManyToMany.TopicManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Models.ManyToMany
{
    public class TopicToStoryConectorModel_FluentClass : IEntityTypeConfiguration<TopicToStoryConectorModel>
    {
        public void Configure(EntityTypeBuilder<TopicToStoryConectorModel> builder)
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
