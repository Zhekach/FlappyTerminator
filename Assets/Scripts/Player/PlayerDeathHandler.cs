public class PlayerDeathHandler
{
    private Player _player;
    private GameFlow _gameFlow;
    
    public PlayerDeathHandler(Player player, GameFlow gameFlow)
    {
        _player = player;
        _gameFlow = gameFlow;
        _player.Died += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        _gameFlow.GameOver();
    }
 
}
