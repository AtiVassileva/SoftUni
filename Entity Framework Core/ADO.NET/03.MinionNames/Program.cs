using System;
using Microsoft.Data.SqlClient;

namespace _03.MinionNames
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
            var villainNameQuery = $"SELECT Name FROM Villains WHERE Id = @Id";

            using var command = new SqlCommand(villainNameQuery, connection);
            command.Parameters.AddWithValue("@Id", villainId);
            var villainName = command.ExecuteScalar();

            var minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {villainName}");

                using var cmd = new SqlCommand(minionsQuery, connection);
                cmd.Parameters.AddWithValue("@Id", villainId);
                using var reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Console.WriteLine("(no minions)");
                    return;
                }

                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                }
            }
        }
    }
}