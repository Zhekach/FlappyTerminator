public class EndWindow : Window
{
    private void Awake()
    {
        GameFlow.GameStateChanged += Open;
    }
    
    protected override void OnButtonClick()
    {
        throw new System.NotImplementedException();
    }

    protected override void Open(GameState gameState)
    {
        if (gameState == GameState.GameOver)
            gameObject.SetActive(true);
    }

    protected override void Close(GameState gameState)
    {
        throw new System.NotImplementedException();
    }
}
