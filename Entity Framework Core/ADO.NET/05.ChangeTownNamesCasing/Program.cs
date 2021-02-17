using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace _05.ChangeTownNamesCasing
{
    public class Program
    {
        private const string ConnectionString =
            "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        public static void Main()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var countryName = Console.ReadLine();

            const string updateTownsQuery = @"UPDATE Towns
                                    SET Name = UPPER(Name)
                    WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            
            const string getUpdatedTownNamesQuery = @"SELECT t.Name 
                                    FROM Towns as t
                            JOIN Countries AS c ON c.Id = t.CountryCode
                        WHERE c.Name = @countryName";

            using var updateTownsCmd = new SqlCommand(updateTownsQuery, connection);
            updateTownsCmd.Parameters.AddWithValue("@countryName", countryName);
            var affectedRows = updateTownsCmd.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{affectedRows} town names were affected. ");
                using var printTownsCmd = new SqlCommand(getUpdatedTownNamesQuery, connection);
                printTownsCmd.Parameters.AddWithValue("@countryName", countryName);
                using var reader = printTownsCmd.ExecuteReader();

                var output = new List<string>();

                while (reader.Read())
                {
                    output.Add((string)reader[0]);
                }

                Console.WriteLine($"[{string.Join(", ", output)}]");
            }
        }
    }
}