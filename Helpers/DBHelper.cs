using System.Configuration;
using System.Data.SqlClient;

namespace FS_Bookstore.Helpers
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        }
    }
}
