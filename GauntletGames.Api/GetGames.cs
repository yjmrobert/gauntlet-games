using System.Globalization;
using System.Net;
using Azure.Data.Tables;
using GauntletGames.Domain.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace GauntletGames.Api;

public static class GetGames
{
    [Function("GetGames")]
    public static async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("GetGames");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var games = GetGauntletGamesList();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(games);
        return response;
    }

    private static async Task<List<Game>> GetGauntletGamesList()
    {
        var connectionString = Environment.GetEnvironmentVariable("GauntletGamesStorageTableConnectionString");
        var tableName = Environment.GetEnvironmentVariable("GauntletGamesStorageTableName");

        var tableServiceClient = new TableServiceClient(connectionString);
        
        var tableClient = tableServiceClient.GetTableClient(tableName);
        var query = tableClient.QueryAsync<TableEntity>();
        
        var games = new List<Game>();
        await foreach (var entity in query)
        {
            var game = new Game
            {
                Id = int.Parse(entity.RowKey),
                Name = entity["Name"] as string ?? string.Empty,
                ImageUrl = entity["ImageUrl"] as string ?? string.Empty,
                GameDateTime = DateTime.Parse(entity["GameDateTime"].ToString()!),
                GameLocation = entity["GameLocation"] as string ?? string.Empty,
                MaxPlayers = (int)entity["MaxPlayers"]
            };
            
            games.Add(game);
        }
        
        return games;
    }
}