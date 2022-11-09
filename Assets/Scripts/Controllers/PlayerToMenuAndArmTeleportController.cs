using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AosSdk.Core.PlayerModule;

public class PlayerToMenuAndArmTeleportController : MonoBehaviour
{
    [Space]
    [SerializeField] private Transform _menuPosition;
    [SerializeField] private TeleportController _teleportController;
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    private bool _canTeleport = true;

    private Vector3 _currentPlayerPosition = new Vector3();

    public void TeleportToMainMenuLocation()
    {
        TeleportPlayer(_menuPosition);
    }

    private void TeleportPlayer(Transform newPos)
    {
        if (_canTeleport)
        {
            _currentPlayerPosition = _teleportController.GetCurrentPlayerMode().position;
            Player.Instance.TeleportTo(newPos);
            _teleportController.OnStartTeleporting(newPos);
            _cameraFadeIn.FadeStart = true;
        }
    }
    public void TeleportToPreviousLocation()
    {
        if (_canTeleport)
        {
            _cameraFadeIn.FadeStart=true;
            Player.Instance.TeleportTo(_currentPlayerPosition);

        }
    }
    public void AllowTeleport(bool value)
    {
        _canTeleport = value;
    }
}

