using System;

namespace DockerTestProject {
    public class StartupHelper {
        public static string GetConnectionString(string url) {
            var uri = new Uri(url);
            var userInfo = uri.UserInfo.Split(':');
            var username = userInfo[0];
            var password = userInfo.Length > 1 ? userInfo[1] : null;
            var port = uri.Port == -1 ? 5432 : uri.Port;
            var databaseName = uri.PathAndQuery.Substring(1);
            return GetConnectionString(uri.Host, port, databaseName, username, password);
        }

        public static string GetConnectionString(
            string address,
            int port,
            string databaseName,
            string userid = "postgres",
            string password = "") {
            return $"Server={address};Port={port};Database={databaseName};User Id={userid};Password={password}";
        }
    }
}
