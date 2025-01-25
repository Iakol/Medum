using Microsoft.EntityFrameworkCore;

namespace MediumDataBaseManagerAzureApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

    }
}
