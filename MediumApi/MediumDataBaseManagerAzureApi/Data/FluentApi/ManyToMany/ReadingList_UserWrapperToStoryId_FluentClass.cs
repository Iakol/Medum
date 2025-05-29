using MediumDataBaseManagerAzureApi.Models.ManyToMany.ReadingListManyToMany;
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

            //Link To save Story in LIst

            builder.HasOne(sh => sh.SaveStoryInList).WithMany().HasForeignKey(x => x.SaveStoryInListId);

            //Link UserReadingListId

            builder.HasOne(sh => sh.userReadingList).WithMany(rl => rl.SaveStoryInList).HasForeignKey(x => x.UserReadingListId);


            // Other Configuration
        }
    }
}
