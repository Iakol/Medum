﻿using MediumDataBaseManagerAzureApi.Models.ManyToMany;
using MediumDataBaseManagerAzureApi.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.User_Fluent
{
    public class UserWrapper_FluentClass : IEntityTypeConfiguration<UserWrapper>
    {
        public void Configure(EntityTypeBuilder<UserWrapper> builder)
        {
            // primary Key
            builder.HasKey(x => x.UserId);
            // Propetries
            // Relationship


            builder.HasOne(u => u.User).WithOne(u => u.UserWrapper).HasForeignKey<UserWrapper>(u => u.UserId);
            builder.HasMany<UserReadingList>(w => w.ReadingLists).WithOne(r => r.User).HasForeignKey(r => r.UserId);


            //builder.HasMany(u => u.ReadingList).WithMany().UsingEntity<ReadingList_UserWrapperToStoryId>();
            //UserStories in Story Wrapper FluentClass

            //User Profile Cred
            builder.HasOne(u => u.UserMemberShip).WithOne(m => m.UserWrapper).HasForeignKey<UserMemberShipModel>(m => m.UserWrapperId);
            builder.HasOne(u => u.Profile).WithOne(m => m.User).HasForeignKey<UserProfile>(m => m.UserWrapperId);
            //AboutContent in describe in AboutContent FluentClass

            //User to Folow
            builder.HasMany(u => u.Relationships).WithOne(f => f.User).HasForeignKey(f => f.UserID);


            // Other Configuration
        }
    }
}
