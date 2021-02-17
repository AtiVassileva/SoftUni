using System;
using Microsoft.Data.SqlClient;

namespace _02.VilliansNames
{
    public class Program
    {
        private const string ConnectionString =
            "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        public static void Main()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            const string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                        FROM Villains AS v 
                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                        GROUP BY v.Id, v.Name 
                        HAVING COUNT(mv.VillainId) > 3 
                        ORDER BY COUNT(mv.VillainId)";

            using var command = new SqlCommand(query, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var villainName = reader[0];
                var minionsCount = reader[1];
                Console.WriteLine($"{villainName} - {minionsCount}");
            }
        }
    }
}