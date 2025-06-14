using MediumDataBaseManagerAzureApi.Data.FluentApi.ContentState_Fluent;
using MediumDataBaseManagerAzureApi.Data.FluentApi.ContentStateWrapper_Fluent;
using MediumDataBaseManagerAzureApi.Data.FluentApi.ManyToMany;
using MediumDataBaseManagerAzureApi.Data.FluentApi.User_Fluent;
using MediumDataBaseManagerAzureApi.Models.ContentState;
using MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart;
using MediumDataBaseManagerAzureApi.Models.FollowClass;
using MediumDataBaseManagerAzureApi.Models.ManyToMany;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.Read;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.ReadingListManyToMany;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.StoryWrapperManyToMany;
using MediumDataBaseManagerAzureApi.Models.ManyToMany.TopicManyToMany;
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


        //User
        public DbSet<UserWrapper> UserWrappers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserReadingList> UsersReadingLists { get; set; }
        public DbSet<UserMemberShipModel> UserMemberShips { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserBlockModel> UserBlocks { get; set; }
        public DbSet<UserMuteModel> UserMutes { get; set; }

        //Topic
        public DbSet<TopicModel> Topics{ get; set; }

        //Many to Many Tables
        public DbSet<TopicToStoryConectorModel> TopicToStoryConectors { get; set; }
        public DbSet<StoryToAuthorsConectorModel> StoryToAuthorsConectors { get; set; }
        public DbSet<ReadingList_UserWrapperToStoryId> ReadingList_UserWrapperToStoryIds { get; set; }
        public DbSet<FollowModel> Follows { get; set; }
            //--Readers
        public DbSet<ReadersModel> Readers { get; set; }
        public DbSet<Responce> Responces { get; set; }
        public DbSet<ClapsToResponceOfUsers> ClapsToResponcesOfUsers { get; set; }



        //ContentState Wrapers
        public DbSet<ContentStateAboutUserWrapperModel> ContentStateAboutUserWrappers { get; set; }
        public DbSet<ContentStateStoryWrapperModel> ContentStateStoryWrappers { get; set; }

        //ContentState
        public DbSet<ContentStateModel> ContentStates { get; set; }
        public DbSet<BlockModel> Blocks { get; set; }
        public DbSet<DictonaryDataInBlockModel> DictonaryDataInBlocks { get; set; }
        public DbSet<EntityMapModel> EntityMaps { get; set; }
        public DbSet<EntityRangeModel> EntityRanges { get; set; }
        public DbSet<InlineStylesRangeModel> InlineStylesRanges { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User Wraper
            modelBuilder.ApplyConfiguration(new UserWrapper_FluentClass());
            modelBuilder.ApplyConfiguration(new User_FluentClass());
            modelBuilder.ApplyConfiguration(new UserReadingList_FluentClass());
            modelBuilder.ApplyConfiguration(new UserMemberShipModel_FluentClass());
            modelBuilder.ApplyConfiguration(new UserProfile_FluentClass());
            modelBuilder.ApplyConfiguration(new UserBlock_FluentClass());
            modelBuilder.ApplyConfiguration(new UserMute_FluentClass());



            //Topic
            modelBuilder.ApplyConfiguration(new TopicModel_FluentClass());


            //ManyToMany
            modelBuilder.ApplyConfiguration(new TopicToStoryConectorModel_FluentClass());
            modelBuilder.ApplyConfiguration(new StoryToAuthorsConectorModel_FluentClass());
            modelBuilder.ApplyConfiguration(new ReadingList_UserWrapperToStoryId_FluentClass());
            modelBuilder.ApplyConfiguration(new FollowModel_FluentClass());
                //--Read
            modelBuilder.ApplyConfiguration(new ReadersModel_FluentClass());
            modelBuilder.ApplyConfiguration(new Responce_FluentClass());
            modelBuilder.ApplyConfiguration(new ClapsToResponceOfUsers_FluentClass());



            //ContentState
            modelBuilder.ApplyConfiguration(new BlockModel_FluentClass());
            modelBuilder.ApplyConfiguration(new ContentStateModel_FluentClass());
            modelBuilder.ApplyConfiguration(new DictonaryDataInBlockModel_FluentClass());
            modelBuilder.ApplyConfiguration(new EntityMapModel_FluentClass());
            modelBuilder.ApplyConfiguration(new EntityRangeModel_FluentClass());
            modelBuilder.ApplyConfiguration(new InlineStylesRangeModel_FluentClass());

            //ContentState Wrapers
            modelBuilder.ApplyConfiguration(new ContentStateAboutUserWrapperModel_FluentClass());
            modelBuilder.ApplyConfiguration(new ContentStateStoryWrapperModel_FluentClass());













        }



    }
}
