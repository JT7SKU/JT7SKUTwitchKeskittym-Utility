public class Program
{
    public static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);
        var BottiR = builder.AddOrleans("bottiR");
        builder.Build().Run();
    }
}