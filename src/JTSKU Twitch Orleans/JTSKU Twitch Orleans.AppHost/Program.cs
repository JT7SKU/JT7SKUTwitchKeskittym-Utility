namespace JT7SKUtwitchR.AppHost { 
public class Program
{
    public static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        builder.AddProject<Projects.Services_Kohdistuma_Unit_Twitch_OData>("KohistumuData");

        builder.Build().Run();
    }
}
}