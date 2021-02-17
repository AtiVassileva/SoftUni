using System;
using Microsoft.Data.SqlClient;

namespace _06.RemoveVillain
{
    public class Program
    {
        private const string ConnectionString =
            "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        public static void Main()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var villainId = int.Parse(Console.ReadLine());

            const string selectVillainNameQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";
            using var villianNameCmd = new SqlCommand(selectVillainNameQuery, connection);
            villianNameCmd.Parameters.AddWithValue("@villainId", villainId);

            var villainName = (string)villianNameCmd.ExecuteScalar();

            if (villainName == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            const string deleteMinionsQuery = @"DELETE FROM MinionsVillains 
                            WHERE VillainId = @villainId";
            const string deleteVillainQuery = @"DELETE FROM Villains
                                 WHERE Id = @villainId";


            using var deleteMinionsCmd = new SqlCommand(deleteMinionsQuery, connection);
            deleteMinionsCmd.Parameters.AddWithValue("@villainId", villainId);
            var deleteMinionsCount = deleteMinionsCmd.ExecuteNonQuery();

            using var deleteVillainCmd = new SqlCommand(deleteVillainQuery, connection);
            deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);
            deleteVillainCmd.ExecuteNonQuery();

            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{deleteMinionsCount} minions were released.");
        }
    }
}