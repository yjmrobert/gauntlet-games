using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace GauntletGames.Api;

public static class PlayerSignup
{
    [Function("PlayerSignup")]
    public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("PlayerSignup");
        logger.LogInformation("C# HTTP trigger function processed a request.");
        //
        //
        // // get the post data
        // var requestBody = await req.ReadAsJsonAsync<PlayerSignupRequest>();
        //
        //
        // return response;
        return null;

    }
}