using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public UnityAction SceneChangerEvent;
    [SerializeField] private TeleportDoor[] _teleportDoors;
    private void Awake()
    {
        foreach (var door in _teleportDoors)
        {
            door.DoorClickedEvent += OnTeleportToLocaion;
        }
    }
    private void OnTeleportToLocaion(string locationName)
    {
        SceneChangerEvent?.Invoke();
        SceneManager.LoadScene(locationName);
    }
}
