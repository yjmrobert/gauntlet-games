namespace GauntletGames.Domain.Models;

public class GameNote
{
    public int Id { get; set; }
    public string Note { get; set; } = null!;
    
    public int GameId { get; set; }
    public Game? Game { get; set; }
    
}