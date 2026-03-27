using System;
using UnityEngine;

public class GameFlow
{
    private GameState _gameState;
    
    public event Action<GameState> GameStateChanged;
    
    public GameFlow()
    {
        _gameState = GameState.None;
    }

    public void StartGame()
    {
        SetState(GameState.Playing);
    }

    public void PauseGame()
    {
        SetState(GameState.Paused);
    }

    public void GameOver()
    {
        SetState(GameState.GameOver);
    }
    
    private void SetState(GameState state)
    {
        _gameState = state;
        GameStateChanged?.Invoke(_gameState);
    }
}
