using System;
using UnityEngine;

public class GameFlow
{
    private StartWindow _startWindow;
    private EndWindow _endWindow;
    
    private GameState _gameState;
    
    public event Action<GameState> GameStateChanged;
    
    public GameFlow(EndWindow endWindow, StartWindow startWindow)
    {
        _startWindow = startWindow;
        _endWindow = endWindow;
        ResetGame();
        
        _startWindow.PlayButtonClick += OnPlayButtonClicked;
    }
    
    public void ResetGame()
    {
        SetState(GameState.ResetGame);
        _endWindow.Close();
        _startWindow.Open();
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        SetState(GameState.Playing);
        _startWindow.Close();
        Time.timeScale = 1f;
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

    private void OnPlayButtonClicked()
    {
        StartGame();
    }
}
