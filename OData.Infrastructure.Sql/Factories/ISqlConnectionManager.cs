using Microsoft.Data.SqlClient;

namespace OData.Infrastructure.Sql.Factories
{
    public interface ISqlConnectionManager : IDisposable
    {
        SqlConnection Get();
    }
}