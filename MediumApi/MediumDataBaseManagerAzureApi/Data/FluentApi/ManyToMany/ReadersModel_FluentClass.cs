using MediumDataBaseManagerAzureApi.Models.ManyToMany.Read;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ManyToMany
{
    public class ReadersModel_FluentClass : IEntityTypeConfiguration<ReadersModel>
    {
        public void Configure(EntityTypeBuilder<ReadersModel> builder)
        {
            // primary Key
            builder.HasKey(x => new {x.UserId,x.ReadId });
            // Propetries
            // Relationship   
            // Other Configuration
        }
    }
}
