using UnityEngine;

public class CameraPlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _player.transform.position.x + _xOffset;
        transform.position = position;
    }
}