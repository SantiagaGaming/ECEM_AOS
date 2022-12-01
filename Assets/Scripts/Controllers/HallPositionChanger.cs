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
        StartCoroutine(TeleportDelay());
    }
    private IEnumerator TeleportDelay()
    {
        yield return new WaitForSeconds(0.2f);
        _prevousLocation = SceneSettings.Instance.Memory.PrevousLocation;
        if (_prevousLocation != null)
        {
            Transform newPlayerPos = _playerPositions.FirstOrDefault(t => t.name == _prevousLocation);
            if (newPlayerPos != null)
            {
                Player.Instance.TeleportTo(newPlayerPos);
                Debug.Log(_prevousLocation + "FROM HALL POSITIONS");
            }
            else Debug.Log("Not found  " + newPlayerPos + _prevousLocation);

        }
    }
}
