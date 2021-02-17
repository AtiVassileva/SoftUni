using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace _07.PrintAllMinionNames
{
    public class Program
    {
        private const string ConnectionString =
            "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        public static void Main()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            const string selectMinionNamesQuery = "SELECT Name FROM Minions";
            using var minionNamesCmd = new SqlCommand(selectMinionNamesQuery, connection);

            using var reader = minionNamesCmd.ExecuteReader();

            var minions = new List<string>();

            while (reader.Read())
            {
                minions.Add((string)reader[0]);
            }

            Console.WriteLine(string.Join(", ", minions));

            var counter = 0;
            for (var i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[counter]);
                Console.WriteLine(minions[minions.Count - 1 - counter]);
                counter++;
            }

            if (minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count / 2]);
            }
        }
    }
}