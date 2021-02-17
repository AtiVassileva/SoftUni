using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace _08.IncreaseMinionAge
{
    public class Program
    {
        private const string ConnectionString =
            "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        public static void Main()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var minionIds = Console.ReadLine()
                .Split(" ").Select(int.Parse).ToArray();

            const string updateMinionsQuery = @"UPDATE Minions
            SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                            WHERE Id = @Id";

            foreach (var id in minionIds)
            {
               using var updateMinionCmd = new SqlCommand(updateMinionsQuery, connection);
               updateMinionCmd.Parameters.AddWithValue("@Id", id);
               updateMinionCmd.ExecuteNonQuery();
            }

            const string selectMinionsQuery = @"SELECT Name, Age FROM Minions";
            using var selectMinionsCmd = new SqlCommand(selectMinionsQuery, connection);
            using var reader = selectMinionsCmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }
    }
}