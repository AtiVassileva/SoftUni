namespace CarShop.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;
        public const int DefaultMaxLength = 20;

        //User
        public const int UsernameMinLength = 4;
        public const int PasswordMinLength = 5;
        public const string ValidEmailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string Client = "Client";
        public const string Mechanic = "Mechanic";

        //Car
        public const int ModelMinLength = 5;
        public const int CarPlateNumberMaxLength = 8;
        public const string CarPlateNumberRegex = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const int CarYearMinValue = 1900;
        public const int CarYearMaxValue = 2100;

        //Issue
        public const int IssueDescriptionMinLength = 5;
    }
}
