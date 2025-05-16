using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MediumDataBaseManagerAzureApi.Models.User;
using MediumDataBaseManagerAzureApi.Models.ManyToMany;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.User_Fluent
{
    public class UserReadingList_FluentClass : IEntityTypeConfiguration<UserReadingList>
    {
        public void Configure(EntityTypeBuilder<UserReadingList> builder)
        {
            // primary Key
            builder.HasKey(x => x.Id);
            // Propetries
            // Relationship
            builder.HasMany<ReadingList_UserWrapperToStoryId>(rl => rl.SaveStoryInList).WithOne();


            // Other Configuration
        }
    }
}
