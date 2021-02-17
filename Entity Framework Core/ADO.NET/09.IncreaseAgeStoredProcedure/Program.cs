using System;
using Microsoft.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    public class Program
    {
        private const string ConnectionString =
            "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        public static void Main()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var minionId = int.Parse(Console.ReadLine());

            const string execProcQuery = "EXEC usp_GetOlder @id";

            using var execProcCmd = new SqlCommand(execProcQuery, connection);
            execProcCmd.Parameters.AddWithValue("@id", minionId);
            execProcCmd.ExecuteNonQuery();

            const string selectMinionQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";
            
            using var selectMinionCmd = new SqlCommand(selectMinionQuery, connection);
            selectMinionCmd.Parameters.AddWithValue("@Id", minionId);
            using var reader = selectMinionCmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]} years old");
            }
        }
    }
}