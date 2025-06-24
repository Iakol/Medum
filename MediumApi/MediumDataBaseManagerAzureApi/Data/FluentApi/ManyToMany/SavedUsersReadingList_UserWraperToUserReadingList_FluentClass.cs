using MediumDataBaseManagerAzureApi.Models.ManyToMany.Read;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.ReadingListManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ManyToMany
{
    public class SavedUsersReadingList_UserWraperToUserReadingList_FluentClass : IEntityTypeConfiguration<SavedUsersReadingList_UserWraperToUserReadingList>
    {
        public void Configure(EntityTypeBuilder<SavedUsersReadingList_UserWraperToUserReadingList> builder)
        {
            builder.HasKey(s => new { s.UserReadingListToSave, s.ReadingListId });

            //relationship
            builder.HasOne(s => s.UserReadingListToSave).WithMany().HasForeignKey(s => s.UserReadingListToSave);
            builder.HasOne(s => s.UserId).WithMany().HasForeignKey(s => s.UserId);

        }
    }
}
