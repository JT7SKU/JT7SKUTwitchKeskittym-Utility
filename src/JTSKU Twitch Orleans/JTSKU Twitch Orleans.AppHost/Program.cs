internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        builder.AddProject<Projects.Services_Kohdistuma_Unit_Twitch_OData>("services-kohdistuma-unit-twitch-odata");

        builder.Build().Run();
    }
}