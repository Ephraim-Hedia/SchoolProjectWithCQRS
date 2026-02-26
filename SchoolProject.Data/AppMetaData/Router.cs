namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "api";
        public const string version = "v1";
        public const string baseRoute = root + "/" + version + "/";

        public static class studentRouting
        {
            public const string prefix = baseRoute + "student/";
            public const string getAll = prefix;
            public const string getAllPaginated = prefix + "Paginated";
            public const string getById = prefix + "{id}";
            public const string create = prefix;
            public const string update = prefix;
            public const string delete = prefix + "{id}";
        }
    }
}
