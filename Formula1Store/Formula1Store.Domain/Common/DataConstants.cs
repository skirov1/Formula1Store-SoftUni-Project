using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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

        public static class Order
        {
            public const int UserFullNameMaxLength = 100;
            public const int UserFullNameMinLength = 4;

            public const int UserPhoneNumberMaxLength = 10;     
        }

        public static class Product
        {
            public const int ProductNameMaxLength = 50;
            public const int ProductNameMinLength = 3;

            public const int DescriptionMaxLength = 1000;
        }

        public static class Category
        {
            public const int CategoryNameMaxLength = 50;    
        }

        public static class Common
        {
            public const string DateFormat = "{0:dd/MM/yyyy}";
        }
    }
}
