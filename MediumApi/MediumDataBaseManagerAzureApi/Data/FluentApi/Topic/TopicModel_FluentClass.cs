using MediumDataBaseManagerAzureApi.Models.ManyToMany;
using MediumDataBaseManagerAzureApi.Models.Topic;
using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.User_Fluent
{
    public class TopicModel_FluentClass : IEntityTypeConfiguration<TopicModel>
    {
        public void Configure(EntityTypeBuilder<TopicModel> builder)
        {
            // primary Key
            builder.HasKey(x => x.TopicId);
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
