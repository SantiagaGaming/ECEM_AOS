using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HallPositionChanger : MonoBehaviour
{
    [SerializeField] private Transform[] _playerPositions;
    private string _prevousLocation;
    private void Start()
    {
        _prevousLocation = PlayerPrefs.GetString("PrevousSceneName");
        if(_prevousLocation!=null)
        {
            Transform newPlayerPos = _playerPositions.FirstOrDefault(t => t.name == _prevousLocation);
            if (newPlayerPos != null)
                Player.Instance.TeleportTo(newPlayerPos);
        }
    }
}
