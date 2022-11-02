using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AosSdk.Core.PlayerModule;

public class PlayerToMenuTeleportController : MonoBehaviour
{
    [SerializeField] private CameraFlash _cameraFlash;
    [Space]
    [SerializeField] private Transform _menuPosition;
    [SerializeField] private TeleportController _teleportController;
    private bool _canTeleport = true;

    private Vector3 _currentPlayerPosition = new Vector3();

    public void TeleportToMainMenuLocation()
    {
        if (_canTeleport)
        {
            _currentPlayerPosition = _teleportController.GetCurrentPlayerMode().position;
            Player.Instance.TeleportTo(_menuPosition);
            _teleportController.OnStartTeleporting(_menuPosition);
            _cameraFlash.CameraFlashStart();
        }

    }
    public void TeleportToPreviousLocation()
    {
        if (_canTeleport)
        {
            _cameraFlash.CameraFlashStart();
            Player.Instance.TeleportTo(_currentPlayerPosition);

        }
    }
    public void AllowTeleport(bool value)
    {
        _canTeleport = value;
    }
}

