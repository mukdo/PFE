using System.Threading.Tasks;

namespace PFE.Data
{
    public interface ISeed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }
}
