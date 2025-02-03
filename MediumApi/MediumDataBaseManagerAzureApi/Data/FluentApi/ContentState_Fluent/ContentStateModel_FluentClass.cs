using MediumDataBaseManagerAzureApi.Models.ContentState;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediumDataBaseManagerAzureApi.Data.FluentApi.ContentState_Fluent
{
    public class ContentStateModel_FluentClass : IEntityTypeConfiguration<ContentStateModel>
    {
        public void Configure(EntityTypeBuilder<ContentStateModel> builder)
        {
            // primary Key
            builder.HasKey(x => x.Id);
            // Propetries

            //Relationship
            //other Configuration


            //
            // primary Key
            // Propetries
            // Relationship
            // Other Configuration
        }
    }
}
