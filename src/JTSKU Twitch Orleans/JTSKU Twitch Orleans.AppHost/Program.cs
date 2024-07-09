using Aspire.Hosting;
using Google.Protobuf.WellKnownTypes;

namespace JT7SKUtwitchR.AppHost { 
public class Program
{
    public static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);
            //string storage = builder.AddAzureStorage("storage").RunAsEmulator();
            //var stormTable = storage.AddTables("storming");
            //var Grainstorage = storage.AddBlobs("grain-stage");

            var twitchr = builder.AddOrleans("default")/*.WithClustering(stormTable).WithGrainStorage("default", Grainstorage)*/;

        builder.Build().Run();
    }
}
}