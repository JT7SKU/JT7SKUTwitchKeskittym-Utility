internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);
        var KhatR = builder.AddOrleans("khattiR");

        builder.Build().Run();
    }
}