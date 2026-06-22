namespace Project_Task_Management.Data.AppMetaData
{
    public static class Router
    {
        public const string Root = "Api";
        public const string Version = "V1";
        public const string Rule = Root + "/" + Version + "/";
        public const string SingleRoute = "/{id}";


        public static class ProjectRouting
        {
            public const string Prefix = Router.Rule + "Project";

            public const string List = Prefix + "/List";
            public const string GetById = Prefix + Router.SingleRoute;
            public const string GetByUserId = Prefix + "/User/{userId}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Update";
            public const string Delete = Prefix + "/{id}";
        }

        public static class TaskRouting
        {
            public const string Prefix = Router.Rule + "Project/{projectId}/Task";
            public const string Create = Prefix + "/Create";
            public const string UpdateStatus = Prefix + "/{taskId}/UpdateStatus";
            public const string GetTasksByProject = Prefix + "/List";
            public const string Delete = Prefix + "/{taskId}";
        }
    }
}
