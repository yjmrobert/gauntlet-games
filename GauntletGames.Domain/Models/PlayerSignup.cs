using Azure;
using Azure.Data.Tables;

namespace GauntletGames.Domain.Models;

public class PlayerSignup : ITableEntity
{
    public string PartitionKey { get; set; } = "player-signups";
    public string RowKey { get; set; } = Guid.NewGuid().ToString();
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    
    public string PlayerRowKey { get; set; } = null!;
    public string GameRowKey { get; set; } = null!;
}