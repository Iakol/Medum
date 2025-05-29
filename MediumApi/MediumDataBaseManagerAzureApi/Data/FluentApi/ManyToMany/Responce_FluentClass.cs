using MediumDataBaseManagerAzureApi.Models.ManyToMany.Read;
using Microsoft.EntityFrameworkCore;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ManyToMany
{
    public class Responce_FluentClass : IEntityTypeConfiguration<Responce>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Responce> builder)
        {
            // primary Key
            builder.HasKey(x => x.ResponceId);
            // Propetries
            // Relationship   
            // Other Configuration
        }
    }
}
