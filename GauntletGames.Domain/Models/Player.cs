namespace GauntletGames.Domain.Models;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    
    public List<Game> Games { get; set; } = null!;
    
}