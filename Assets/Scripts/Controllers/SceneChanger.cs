using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

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
        Debug.Log("in teleport");
        SceneManager.LoadScene(locationName);
    }
}
