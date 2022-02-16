using System.Data.SqlClient;

namespace ST.ARC.DataAccess
{
    public class DBHelperSql
    {
        public static string ConnectionString = "Server=.;Initial Catalog=LogManager;Persist Security Info=True;User ID=adminstone;Password=Ad123456;";

        public static int ExcuteSql(string sqlString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }


            }
        }

        public static void LogInfo(string message)
        {
            var sql = $"insert into [dbo].[Log4Net] values ('{DateTime.UtcNow}', 'test','info','stone', '{message}' ,'-')";

            ExcuteSql(sql);
        }
    }
}