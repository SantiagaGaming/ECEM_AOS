using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AosSdk.Core.Interaction.Interfaces;
using UnityEngine.Events;
using AosSdk.Core.PlayerModule;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private GameObject _descPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [SerializeField] private TeleportDoor[] _doors;
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    [HideInInspector] public bool CanTeleport = true;


    private void Awake()
    {
        foreach (var Door in _doors)
        {
            Door.TeleportToObjectEvent += OnStartTeleporting;
        }
    }
    public void OnStartTeleporting(Transform newPlayerPosition)
    {
        if (CanTeleport)
        {
            Player.Instance.CanMove = false;
            Player.Instance.TeleportTo(newPlayerPosition);
            _descPlayer.transform.rotation = newPlayerPosition.rotation;
            _vrPlayer.transform.rotation = newPlayerPosition.rotation;
            Player.Instance.CanMove = true;
            _cameraFadeIn.FadeStart = true;
        }

    }
    public Transform GetCurrentPlayerMode()
    {
        if (_descPlayer.activeSelf == true)
            return _descPlayer.transform;
        else return _vrPlayer.transform;
    }
}
