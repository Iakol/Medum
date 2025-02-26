﻿// <auto-generated />
using System;
using MediumDataBaseManagerAzureApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MediumDataBaseManagerAzureApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateAboutUserWrapperModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContentStateModelAboutUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SaveLastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ContentStateModelAboutUserId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ContentStateAboutUserWrappers");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("ContentStates");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.BlockModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentStateId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("depth")
                        .HasColumnType("int");

                    b.Property<string>("key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContentStateId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.DictonaryDataInBlockModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<string>("DictonaryKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("obj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("DictonaryDataInBlocks");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.EntityMapModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ContentStateKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DictonaryKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mutability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("ContentStateKey");

                    b.ToTable("EntityMaps");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.EntityRangeModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<int>("key")
                        .HasColumnType("int");

                    b.Property<int>("length")
                        .HasColumnType("int");

                    b.Property<int>("offset")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EntityRanges");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.InlineStylesRangeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<int>("length")
                        .HasColumnType("int");

                    b.Property<int>("offset")
                        .HasColumnType("int");

                    b.Property<string>("style")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("InlineStylesRanges");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateStoryWrapperModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SaveLastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoryCreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserWrapperUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("StoryCreatorId");

                    b.HasIndex("UserWrapperUserId");

                    b.ToTable("ContentStateStoryWrappers");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.FollowClass.FollowModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdToFollow")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ManyToMany.ReadingList_UserWrapperToStoryId", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReadingList_UserWrapperToStoryIds");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ManyToMany.StoryToAuthorsConectorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentStateWrapperId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserWrapperId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ContentStateWrapperId");

                    b.HasIndex("UserWrapperId");

                    b.ToTable("StoryToAuthorsConectors");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ManyToMany.TopicToStoryConectorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentStateWrapperId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<string>("TopicId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ContentStateWrapperId");

                    b.HasIndex("TopicId1");

                    b.ToTable("TopicToStoryConectors");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.Topic.TopicModel", b =>
                {
                    b.Property<string>("TopicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.PrimitiveCollection<string>("Users")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.User.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserWrapperId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.User.UserMemberShipModel", b =>
                {
                    b.Property<string>("UserWrapperId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("EndAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("UserWrapperId");

                    b.ToTable("UserMemberShips");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.User.UserProfile", b =>
                {
                    b.Property<string>("UserWrapperId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserWrapperId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.ToTable("UserWrappers");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateAboutUserWrapperModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateModel", "ContentStateModelAboutUser")
                        .WithOne()
                        .HasForeignKey("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateAboutUserWrapperModel", "ContentStateModelAboutUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", "User")
                        .WithOne("AboutContent")
                        .HasForeignKey("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateAboutUserWrapperModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentStateModelAboutUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.BlockModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateModel", "ContentState")
                        .WithMany("blocks")
                        .HasForeignKey("ContentStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentState");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.DictonaryDataInBlockModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.BlockModel", "Block")
                        .WithMany("data")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.EntityMapModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateModel", "ContentState")
                        .WithMany("entityMap")
                        .HasForeignKey("ContentStateKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentState");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.EntityRangeModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.BlockModel", "Block")
                        .WithMany("entityRanges")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.InlineStylesRangeModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.BlockModel", "Block")
                        .WithMany("inlineStyleRanges")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateStoryWrapperModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateModel", "ContentState")
                        .WithOne()
                        .HasForeignKey("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateStoryWrapperModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", "StoryCreator")
                        .WithMany("UserStories")
                        .HasForeignKey("StoryCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", null)
                        .WithMany("ReadingList")
                        .HasForeignKey("UserWrapperUserId");

                    b.Navigation("ContentState");

                    b.Navigation("StoryCreator");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.FollowClass.FollowModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", "User")
                        .WithMany("Relationships")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ManyToMany.StoryToAuthorsConectorModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateStoryWrapperModel", "ContentStateWrapper")
                        .WithMany("Authors")
                        .HasForeignKey("ContentStateWrapperId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", "UserWrapper")
                        .WithMany()
                        .HasForeignKey("UserWrapperId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ContentStateWrapper");

                    b.Navigation("UserWrapper");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ManyToMany.TopicToStoryConectorModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateStoryWrapperModel", "ContentStateWrapper")
                        .WithMany()
                        .HasForeignKey("ContentStateWrapperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MediumDataBaseManagerAzureApi.Models.Topic.TopicModel", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentStateWrapper");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.User.UserMemberShipModel", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", "UserWrapper")
                        .WithOne("UserMemberShip")
                        .HasForeignKey("MediumDataBaseManagerAzureApi.Models.User.UserMemberShipModel", "UserWrapperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserWrapper");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.User.UserProfile", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", "User")
                        .WithOne("Profile")
                        .HasForeignKey("MediumDataBaseManagerAzureApi.Models.User.UserProfile", "UserWrapperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", b =>
                {
                    b.HasOne("MediumDataBaseManagerAzureApi.Models.User.User", "User")
                        .WithOne("UserWrapper")
                        .HasForeignKey("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateModel", b =>
                {
                    b.Navigation("blocks");

                    b.Navigation("entityMap");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStatePart.BlockModel", b =>
                {
                    b.Navigation("data");

                    b.Navigation("entityRanges");

                    b.Navigation("inlineStyleRanges");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.ContentState.ContentStateStoryWrapperModel", b =>
                {
                    b.Navigation("Authors");
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.User.User", b =>
                {
                    b.Navigation("UserWrapper")
                        .IsRequired();
                });

            modelBuilder.Entity("MediumDataBaseManagerAzureApi.Models.User.UserWrapper", b =>
                {
                    b.Navigation("AboutContent")
                        .IsRequired();

                    b.Navigation("Profile")
                        .IsRequired();

                    b.Navigation("ReadingList");

                    b.Navigation("Relationships");

                    b.Navigation("UserMemberShip")
                        .IsRequired();

                    b.Navigation("UserStories");
                });
#pragma warning restore 612, 618
        }
    }
}
