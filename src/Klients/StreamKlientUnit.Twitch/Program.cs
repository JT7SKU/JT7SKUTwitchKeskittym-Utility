
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StreamKlientUnit.Twitch.TwitchR.Web;
using System.Threading.Tasks;

namespace StreamKlientUnit.Twitch
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = CreateHostBuilder(args);
            builder.RootComponents.Add<App>("app");
            builder.RootComponents.Add<HeadOutlet>("head:after");
            await builder.Build().RunAsync();
        }

        public static WebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            WebAssemblyHostBuilder.CreateDefault(args);
    }
}
