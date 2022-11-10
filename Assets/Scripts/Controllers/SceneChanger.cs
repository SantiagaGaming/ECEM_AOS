using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] private TeleportDoor _teleportDoor;
    private void OnEnable()
    {
        _teleportDoor.DoorClickedEvent += OnTeleportToLocaion;
    }
    private void OnDisable()
    {
        _teleportDoor.DoorClickedEvent -= OnTeleportToLocaion;
    }
    private void OnTeleportToLocaion(string locationName)
    {
        SceneManager.LoadScene(locationName);
    }
}
