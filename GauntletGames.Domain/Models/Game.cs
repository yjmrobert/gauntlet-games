namespace GauntletGames.Domain.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    
    public DateTime GameDateTime { get; set; }
    public string GameLocation { get; set; } = null!;
    public int MaxPlayers { get; set; }

    public List<Player> Players { get; set; } = new();
    public List<GameNote> GameNotes { get; set; } = new();
}