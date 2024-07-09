internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);
        var striimiR = builder.AddOrleans("striimiR");

        builder.Build().Run();
    }
}