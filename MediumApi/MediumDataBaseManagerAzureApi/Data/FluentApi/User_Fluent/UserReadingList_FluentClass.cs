using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MediumDataBaseManagerAzureApi.Models.User;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.ReadingListManyToMany;
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
                
                //Link To save story in List
            builder.HasMany<ReadingList_UserWrapperToStoryId>(rl => rl.SaveStoryInList).WithOne();

                //Link To Readers of ReadingList
            builder.HasMany(w => w.ReaderOfReadingList).WithOne().HasForeignKey(r => r.ReadId);
            builder.HasMany(w => w.ResponceOfReadingList).WithOne().HasForeignKey(r => r.ReadId);


            // Other Configuration
        }
    }
}
