﻿namespace WT.MobileWebService.Contract.V1
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

        public static class CustomerInformation
        {
            public const string Create = Base + "/CustomerInformation";

        }

        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Register = Base + "/identity/register";
            public const string Refresh = Base + "/identity/refresh";

        }

    }
}
