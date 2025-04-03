using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private bool _isPaused;
    private PlayerInput _playerInput;

    private void Start()
    {
        if (player != null)
        {
            _playerInput = player.GetComponent<PlayerInput>();
        }
    }

    private void Update()
    {
        if (!Keyboard.current.escapeKey.wasPressedThisFrame) return;
        _isPaused = !_isPaused;
        FreezeTime(_isPaused);
    }

    private void FreezeTime(bool isFrozen)
    {
        Time.timeScale = isFrozen ? 0 : 1;
        if (isFrozen)
        {
            _playerInput.DeactivateInput();
        }
        else
        {
            _playerInput.ActivateInput();
        }
    }
}
