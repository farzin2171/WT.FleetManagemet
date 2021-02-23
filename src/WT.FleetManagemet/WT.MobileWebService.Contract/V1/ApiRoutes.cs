namespace WT.MobileWebService.Contract.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        public static class Locations
        {
            public const string GetByUserId = Base + "/Locations/{userId}/{startDate}/{endDate}";
            public const string Create = Base + "/Locations";

        }

        public static class CustomerInformations
        {
            public const string Create = Base + "/CustomerInformations";

        }
        public static class Orders
        {
            public const string Create = Base + "/Orders/{customerEmail}";

        }
        public static class Drivers
        {
            public const string Create = Base + "/Drivers";
            public const string Update = Base + "/Drivers";
            public const string UpdateStatus = Base + "/Drivers/driverPhone/{driverPhone}/driverStatus/{driverStatus}";
            public const string GetByPhoneNumber = Base + "/Drivers/{phoneNumber}";


        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
            public const string Refresh = Base + "/identity/refresh";

        }

    }
}
