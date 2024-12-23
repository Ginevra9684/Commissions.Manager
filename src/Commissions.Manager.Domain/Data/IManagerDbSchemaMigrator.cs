using System.Threading.Tasks;

namespace Commissions.Manager.Data;

public interface IManagerDbSchemaMigrator
{
    Task MigrateAsync();
}
