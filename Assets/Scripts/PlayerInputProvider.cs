using UnityEngine;

public class PlayerInputProvider : MonoBehaviour
{
    private CustomPlayerInput _playerInput;
    
    private void OnEnable()
    {
        _playerInput.Enable();
    }
    
    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public CustomPlayerInput GetPlayerInput()
    {
        if (_playerInput == null)
            _playerInput = new CustomPlayerInput();
        
        return _playerInput;
    }
}
