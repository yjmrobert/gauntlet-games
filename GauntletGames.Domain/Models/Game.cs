using Azure;
using Azure.Data.Tables;

namespace GauntletGames.Domain.Models;

public class Game : ITableEntity
{
    public string PartitionKey { get; set; } = "games";
    public string RowKey { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    
    public DateTime GameDateTime { get; set; }
    public string GameLocation { get; set; } = null!;
    public int MaxPlayers { get; set; }

    public List<Player> Players { get; set; } = new();
    public List<GameNote> GameNotes { get; set; } = new();
    
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}