using Azure;
using Azure.Data.Tables;

namespace GauntletGames.Domain.Models;

public class Player : ITableEntity
{
    public string PartitionKey { get; set; } = "players";
    public string RowKey { get; set; } = Guid.NewGuid().ToString();
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    
    public string Name { get; set; } = null!;
    
    public List<Game> Games { get; set; } = null!;

}