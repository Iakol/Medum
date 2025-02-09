using MediumDataBaseManagerAzureApi.Data.FluentApi.ContentState_Fluent;
using MediumDataBaseManagerAzureApi.Data.FluentApi.ContentStateWrapper_Fluent;
using MediumDataBaseManagerAzureApi.Data.FluentApi.User_Fluent;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using MediumDataBaseManagerAzureApi.Models.FollowClass;
using MediumDataBaseManagerAzureApi.Models.ManyToMany;
using MediumDataBaseManagerAzureApi.Models.Topic;
using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.EntityFrameworkCore;

namespace MediumDataBaseManagerAzureApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserMemberShipModel> UserMemberShips { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserWrapper> UserWrappers { get; set; }
        public DbSet<TopicModel> Topics{ get; set; }
        public DbSet<TopicToStoryConectorModel> TopicToStoryConectors { get; set; }
        public DbSet<StoryToAuthorsConectorModel> StoryToAuthorsConectors { get; set; }
        public DbSet<ReadingList_UserWrapperToStoryId> ReadingList_UserWrapperToStoryIds { get; set; }
        public DbSet<FollowModel> Follows { get; set; }
        public DbSet<ContentStateAboutUserWrapperModel> ContentStateAboutUserWrappers { get; set; }
        public DbSet<ContentStateModel> ContentStates { get; set; }
        public DbSet<ContentStateStoryWrapperModel> ContentStateStoryWrappers { get; set; }
        public DbSet<BlockModel> Blocks { get; set; }
        public DbSet<DictonaryDataInBlockModel> DictonaryDataInBlocks { get; set; }
        public DbSet<EntityMapModel> EntityMaps { get; set; }
        public DbSet<EntityRangeModel> EntityRanges { get; set; }
        public DbSet<InlineStylesRangeModel> InlineStylesRanges { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BlockModel_FluentClass());
            modelBuilder.ApplyConfiguration(new ContentStateModel_FluentClass());
            modelBuilder.ApplyConfiguration(new DictonaryDataInBlockModel_FluentClass());
            modelBuilder.ApplyConfiguration(new EntityMapModel_FluentClass());
            modelBuilder.ApplyConfiguration(new EntityRangeModel_FluentClass());
            modelBuilder.ApplyConfiguration(new InlineStylesRangeModel_FluentClass());
            modelBuilder.ApplyConfiguration(new ContentStateAboutUserWrapperModel_FluentClass());
            modelBuilder.ApplyConfiguration(new ContentStateStoryWrapperModel_FluentClass());
            modelBuilder.ApplyConfiguration(new UserWrapper_FluentClass());
            modelBuilder.ApplyConfiguration(new User_FluentClass());
            modelBuilder.ApplyConfiguration(new TopicModel_FluentClass());

            modelBuilder.ApplyConfiguration(new ReadingList_UserWrapperToStoryId_FluentClass());
            modelBuilder.ApplyConfiguration(new StoryToAuthorsConectorModel_FluentClass());
            modelBuilder.ApplyConfiguration(new TopicToStoryConectorModel_FluentClass());
            modelBuilder.ApplyConfiguration(new FollowModel_FluentClass());
            modelBuilder.ApplyConfiguration(new UserMemberShipModel_FluentClass());
            modelBuilder.ApplyConfiguration(new UserProfile_FluentClass());









        }



    }
}
