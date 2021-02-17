using Microsoft.Data.SqlClient;

namespace _01.InitialSetup
{
    public class Program
    {
        private const string ConnectionString =
            "Server=.\\SQLEXPRESS;Integrated Security=true;Database=MinionsDB";

        public static void Main()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            //create db
            const string createDbQuery = "CREATE DATABASE MinionsDB";
            ExecuteNonQuery(connection, createDbQuery);

            // create tables
            var createTableStatements = GetCreateTablesData();
            foreach (var statement in createTableStatements)
            {
                ExecuteNonQuery(connection, statement);
            }

            // insert into tables
            var insertStatements = GetInsertStatements();

            foreach (var statement in insertStatements)
            {
                ExecuteNonQuery(connection, statement);
            }
        }

        private static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using var command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
        private static string[] GetCreateTablesData()
        {
            var statements = new[]
            {
                "CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), " +
                "CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), " +
                "Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, " +
                "Name VARCHAR(50))",
                "CREATE TABLE Villians(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), " +
                "EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id), " +
                "VillianId INT FOREIGN KEY REFERENCES Villians(Id), " +
                "CONSTRAINT PK_Minion_Villian PRIMARY KEY(MinionId, VillianId))"
            };

            return statements;
        }

        private static string[] GetInsertStatements()
        {
            var records = new[]
            {
               "INSERT INTO Countries (Name) VALUES ('Bulgaria'), ('Italy'), ('USA'), ('Greece'), ('Austria')",
                "INSERT INTO Towns (Name, CountryCode) VALUES ('Sofia', 1), ('Rome', 2)," +
                    "('Los Angeles', 3), ('Athens', 4), ('Vienna', 5)",
                "INSERT INTO Minions (Name, Age, TownId) VALUES ('Pierce', 3, 1), ('Estell', 4, 5),"+	
                    "('Ariadne', 2, 3), ('Rockwell', 1, 2), ('Decca', 5, 4)",
                "INSERT INTO EvilnessFactors(Name) VALUES ('super good'), ('good'), ('bad'), ('evil'), ('super evil')",
                "INSERT INTO Villians (Name, EvilnessFactorId) VALUES ('Libbie', 3), ('Wilone', 5), " +
                     "('Ed', 2), ('Minnie', 1), ('Dolley', 4)",
                "INSERT INTO MinionsVillains(MinionId, VillianId) VALUES"+
                    "(1, 1), (2, 2), (3, 3), (4, 4), (5, 5)"
            };

            return records;
        }
    }
}