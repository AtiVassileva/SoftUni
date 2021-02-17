using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace _04.AddMinion
{
    public class Program
    {
        private const string ConnectionString =
            "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";
        public static void Main()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var minionInfo = Console.ReadLine().Split(' ').ToArray();
            var villainName = Console.ReadLine().Split(": ").ToArray()[1];

            var minionName = minionInfo[1];
            var minionAge = int.Parse(minionInfo[2]);
            var minionTown = minionInfo[3];

            var townId = GetTownId(connection, minionTown);

            if (townId == null)
            {
                const string createTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";
                using var createTownCmd = new SqlCommand(createTownQuery, connection);
                createTownCmd.Parameters.AddWithValue("@townName", minionTown);
                createTownCmd.ExecuteNonQuery();
                townId = GetTownId(connection, minionTown);
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            var villainId = GetVillainId(connection, villainName);

            if (villainId == null)
            {
                const string createVillainQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                using var createVillainCmd = new SqlCommand(createVillainQuery, connection);
                createVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                createVillainCmd.ExecuteNonQuery();
                villainId = GetVillainId(connection, villainName);
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            CreateMinion(connection, minionName, minionAge, townId);
            var minionId = GetMinionId(connection, minionName);

            AddMinionToVillain(connection, villainId, minionId);
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void AddMinionToVillain(SqlConnection connection, int? villainId, int? minionId)
        {
            const string addMinionToVillianQuery =
                "INSERT INTO MinionsVillains (VillainId, MinionId) VALUES (@villainId, @minionId)";
            using var addMinionCmd = new SqlCommand(addMinionToVillianQuery, connection);
            addMinionCmd.Parameters.AddWithValue("@villainId", villainId);
            addMinionCmd.Parameters.AddWithValue("@minionId", minionId);
        }

        private static void CreateMinion(SqlConnection connection, string minionName, int minionAge, int? townId)
        {
            const string createMinionQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            using var createMinionCmd = new SqlCommand(createMinionQuery, connection);
            createMinionCmd.Parameters.AddWithValue("@name", minionName);
            createMinionCmd.Parameters.AddWithValue("@age", minionAge);
            createMinionCmd.Parameters.AddWithValue("@townId", townId);
        }

        private static int? GetVillainId(SqlConnection connection, string villainName)
        {
            const string villianIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";
            using var villainCmd = new SqlCommand(villianIdQuery, connection);
            villainCmd.Parameters.AddWithValue("@Name", villainName);
            return (int?)villainCmd.ExecuteScalar();
        }

        private static int? GetTownId(SqlConnection connection, string minionTown)
        {
            const string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
            using var townCommand = new SqlCommand(townIdQuery, connection);
            townCommand.Parameters.AddWithValue("@townName", minionTown);
            return (int?)townCommand.ExecuteScalar();
        }

        private static int? GetMinionId(SqlConnection connection, string minionName)
        {
            const string villianIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
            using var minionCmd = new SqlCommand(villianIdQuery, connection);
            minionCmd.Parameters.AddWithValue("@Name", minionName);
            return (int?)minionCmd.ExecuteScalar();
        }
    }
}