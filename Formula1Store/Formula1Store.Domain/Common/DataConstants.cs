namespace Formula1Store.Domain.Common
{
    public static class DataConstants
    {
        public static class User
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 50;

            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;

            public const int PasswordMinLength = 8;
            public const int PasswordMaxLength = 20;
        }
    }
}
