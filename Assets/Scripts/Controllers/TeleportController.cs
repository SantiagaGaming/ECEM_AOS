using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AosSdk.Core.Interaction.Interfaces;
using UnityEngine.Events;
using AosSdk.Core.PlayerModule;

public class TeleportController : MonoBehaviour
{
    public UnityAction<string> TeleportEvent;
    [SerializeField] private GameObject _descPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [SerializeField] private TeleportDoor[] _doors;
    [SerializeField] private CameraFlash _cameraFlash;
    [HideInInspector] public bool CanTeleport = true;


    private void Awake()
    {
        foreach (var Door in _doors)
        {
            Door.TeleportToObjectEvent += OnStartTeleporting;
        }
    }
    private void OnStartTeleporting(Transform newPlayerPosition, string name)
    {
        if (CanTeleport)
        {
            Player.Instance.CanMove = false;
            Player.Instance.TeleportTo(newPlayerPosition);
            _descPlayer.transform.rotation = newPlayerPosition.rotation;
            _vrPlayer.transform.rotation = newPlayerPosition.rotation;
            Player.Instance.CanMove = true;
            _cameraFlash.CameraFlashStart();
            TeleportEvent?.Invoke(name);

        }

    }
}
