using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;

namespace Twitch_Api.Functions
{
    public static class GetSubscribers
    {
        [Function("GetSubscribers")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] TaskOrchestrationContext context)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("GetSubscribers_Hello", "SharkMark"));
            outputs.Add(await context.CallActivityAsync<string>("GetSubscribers_Hello", "SharkTony"));
            outputs.Add(await context.CallActivityAsync<string>("GetSubscribers_Hello", "SharkNiklas"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [Function("GetSubscribers_Hello")]
        public static string SayHello([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            return $"Hello {name}!";
        }

        [Function("GetSubscribers_HttpStart")]
        public static async Task HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]string instanceId,
            [DurableClient] DurableTaskClient starter,
            ILogger log)
        {
            // Function input comes from the request content.
            await starter.RaiseEventAsync(instanceId,"GetSubscribers", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            
        }
    }
}