using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;

namespace Twitch_Api.Functions
{
    public static class GetFollowers
    {
        [Function("GetFollowers")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] TaskOrchestrationContext context)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("GetFollowers_Hello", "SharkMark"));
            outputs.Add(await context.CallActivityAsync<string>("GetFollowers_Hello", "SharkTony"));
            outputs.Add(await context.CallActivityAsync<string>("GetFollowers_Hello", "SharkNiklas"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }

        [Function("GetFollowers_Hello")]
        public static string SayHello([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"Saying hello to {name}.");
            return $"Hello {name}!";
        }

        [Function("GetFollowers_HttpStart")]
        public static async Task HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]string instanceId,
            [DurableClient]DurableTaskClient starter,
            ILogger log)
        {
            // Function input comes from the request content.
            await starter.RaiseEventAsync(instanceId, "GetFollowers", null);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

        }
    }
}