namespace P05.FootballTeamGenerator.Common
{
    public class GlobalConstants
    {
        
        public static int MinStat = 0;
        public static int MaxStat = 100;


        public static string InvalidNameException =
            "A name should not be empty.";

        public static string InvalidStatException =
            "{0} should be between {1} and {2}.";

        public static string MissingPlayerException =
        "Player {0} is not in {1} team.";

        public static string NonExistingTeamException =
            "Team {0} does not exist.";
    }
}
