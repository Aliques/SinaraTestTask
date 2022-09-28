namespace UserManagement.Common.Endpoints
{
    public static class SyncDataEndPoints
    {
        private static string _root = "api/ad/ActiveDirectory";
        public static string CheckName(string name) => $"{_root}?name={name}";
    }
}
