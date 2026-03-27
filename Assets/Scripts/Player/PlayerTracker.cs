using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private float _xOffset;

    private void Awake()
    {
        _xOffset = this.transform.position.x - _player.transform.position.x;
    }
    
    private void Update()
    {
        var position = transform.position;
        position.x = _player.transform.position.x + _xOffset;
        transform.position = position;
    }
}