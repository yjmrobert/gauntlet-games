using Azure;
using Azure.Data.Tables;

namespace GauntletGames.Domain.Models;

public class GameNote : ITableEntity
{
    public string PartitionKey { get; set; } = "game-notes";
    public string RowKey { get; set; } = Guid.NewGuid().ToString();
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    public string Note { get; set; } = null!;
    
    public string GameRowKey { get; set; }
    public Game? Game { get; set; }

}