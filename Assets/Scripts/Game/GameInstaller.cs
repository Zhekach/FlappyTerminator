using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private ScoresCounter _scoresCounter;
    [SerializeField] private OutOfBoundsDetector _outOfBoundsDetector;
    
    [SerializeField] private ScoresCounterView _scoresCounterView;
    [SerializeField] private EndWindow _endWindow;
    [SerializeField] private StartWindow _startWindow;

    private GameFlow _gameFlow;
    private BulletsSpawner _bulletsSpawner;
    private Pool<Bullet> _bulletsPool;
    private PlayerDeathHandler _playerDeathHandler;

    private void Awake()
    {
        if (_player == null)
            Debug.LogError($"{gameObject.name}: _player reference is null");
        
        if (_enemySpawner == null)
            Debug.LogError($"{gameObject.name}: _enemyGenerator reference is null");
        
        if(_bulletPrefab == null)
            Debug.LogError($"{gameObject.name}: bulletPrefab is null");
        
        if (_scoresCounter == null)
            Debug.LogError($"{gameObject.name}: scoresCounter is null");
        
        if (_outOfBoundsDetector == null)
            Debug.LogError($"{gameObject.name}: outOfBoundsDetector is null");
        
        _bulletsPool = new Pool<Bullet>(_bulletPrefab);
        _bulletsSpawner = new BulletsSpawner(_bulletsPool, _outOfBoundsDetector);
        
        _bulletsPool.Initialize();
        _player.Initialize(_bulletsSpawner);
        _enemySpawner.Initialize(_bulletsSpawner, _outOfBoundsDetector);
        _scoresCounter.Initialize(_enemySpawner);
        

        _scoresCounterView.Initialize(_scoresCounter);
        
        _gameFlow = new GameFlow(_endWindow, _startWindow);
        _playerDeathHandler = new PlayerDeathHandler(_player, _gameFlow);
        _gameFlow.GameStateChanged += OnGameStateChanged;
        _gameFlow.ResetGame();
    }

    private void OnGameStateChanged(GameState gameState)
    {
        if (gameState == GameState.ResetGame)
        {
            _scoresCounter.ResetState();
            _player.Reset();
        }
    }
}