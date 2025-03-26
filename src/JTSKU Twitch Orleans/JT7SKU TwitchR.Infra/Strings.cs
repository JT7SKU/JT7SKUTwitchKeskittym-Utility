namespace JT7SKU_TwitchR.Infra
{
    public static class Defaults
    {
        public static string KlusterName { get; } = "Kluster";
        public static string ServiceName { get; } = "Service";
        public static string SiloName { get; } = "Silo";
        public static int SiloPort { get; } = 11111;
        public static int GatewayPort { get; } = 3000;
    }
    public static class EnviromentVariables
    {
        public static string OrleansKlusterName { get; } = "ORLEANS_KLUSTER_ID";
        public static string OrleansServiceName { get; } = "ORLEANS_SERVICE_NAME";
        public static string OrleansSiloPort { get; } = "ORLEANS_SILO_PORT";
        public static string OrleansPrimarySiloPort { get; } = "ORLEANS_PRIMARY_SILO_PORT";
        public static string OrleansSiloName { get; } = "ORLEANS_SILO_NAME";
        public static string OrleansGatewayPort { get; } = "ORLEANS_GATEWAY_PORT";
        public static string RedisConnectionString { get; } = "REDIS_CONNECTION_STRING";
        public static string WebAppsPrivateIPAddress { get; } = "WEBSITE_PRIVATE_IP";
        public static string WebAppsPrivatePorts { get; } = "WEBSITE_PRIVATE_PORTS"
        public static string KubernetesPodName { get; } = "POD_NAME";
        public static string KubernetesPodNamespace { get; } = "POD_NAMESPACE";
        public static string KubernetesPodIPAddress { get; } = "POD_IP";
    }
}
