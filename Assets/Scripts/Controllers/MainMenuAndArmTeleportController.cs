using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AosSdk.Core.PlayerModule;

public class MainMenuAndArmTeleportController : MonoBehaviour
{
    [SerializeField] private GameObject _descPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [Space]
    [SerializeField] private CameraFlash _cameraFlash;
    [Space]
    [SerializeField] private ModeController _modeController;
    [SerializeField] private Transform _menuPosition;
    [SerializeField] private Transform _armPosition;
    [SerializeField] private GameObject[] _menuButtons;
    [SerializeField] private GameObject _mainMenu;
    private bool _canTeleport = true;

    private Vector3 _currentPlayerPosition = new Vector3();

    public void TeleportToMainMenuLocation()
    {
        TeleportPlayer(_menuPosition);
  
    }
    public void TeleportToArmLocation()
    {
        TeleportPlayer(_armPosition);

    }
    private void TeleportPlayer(Transform newPosition)
    {
        if (_canTeleport)
        {
            _currentPlayerPosition = _modeController.GetPlayerTransform().position;
            Player.Instance.TeleportTo(newPosition);
            _descPlayer.transform.rotation = newPosition.rotation;
            _vrPlayer.transform.rotation = newPosition.rotation;
            _cameraFlash.CameraFlashStart();
        }

    }
    public void TeleportToPreviousLocation()
    {
        if (_canTeleport)
        {
            _cameraFlash.CameraFlashStart();
            Player.Instance.TeleportTo(_currentPlayerPosition);
            foreach (var item in _menuButtons)
            {
                item.SetActive(false);
            }
            _mainMenu.SetActive(true);
        }
    }
    public void AllowTeleport(bool value)
    {
        _canTeleport = value;
    }
}
