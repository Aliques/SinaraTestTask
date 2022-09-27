namespace BlazorApp.Client.Infrastructure.Endpoints
{
    public static class UserServiceEndpoints
    {
        private static string _rootPath = "api/users";
        public static string RootPath = _rootPath;
        public static string Delete(Guid id) => $"{_rootPath}/{id}";
    }
}
