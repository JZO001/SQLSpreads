using System.Data;
using System.Data.SqlClient;

namespace SQLSpreadsTestProjectDec22.Test4
{


    public static class DbQuery
    {

        public static async Task<List<(int, decimal)>> Calculate1(string connectionString)
        {
            string query = "SELECT PeriodKey, SUM(Amount) as SumAmount " +
                "FROM fact_Finance as ff " +
                "GROUP BY ff.PeriodKey";

            return await Query(connectionString, query);
        }

        public static async Task<List<(int, decimal)>> Calculate2(string connectionString)
        {
            string query = "SELECT PeriodKey, SUM(Amount) as SumAmount " +
                "FROM fact_Finance as ff " +
                "WHERE ff.AccountKey <> 1010 " +
                "GROUP BY ff.PeriodKey";

            return await Query(connectionString, query);
        }

        private static async Task<List<(int, decimal)>> Query(string connectionString, string sqlQuery)
        {
            List<(int, decimal)> result = new();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                int periodKey = (int)reader["PeriodKey"];
                                decimal summarizedAmount = (decimal)reader["SumAmount"];
                                result.Add((periodKey, summarizedAmount));
                            }
                        }
                    }
                }
                finally
                {
                    if (connection.State == ConnectionState.Open) connection.Close();
                }
            }

            return result;
        }

    }


}