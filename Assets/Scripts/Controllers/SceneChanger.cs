using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public UnityAction SceneChangerEvent;
    public string PrevousSceneName { get; private set; }

    [SerializeField] private TeleportDoor[] _teleportDoors;

    private void Awake()
    {
        foreach (var door in _teleportDoors)
        {
            door.DoorClickedEvent += OnTeleportToLocation;
        }
        PrevousSceneName = SceneManager.GetActiveScene().name;
    }
    private void OnTeleportToLocation(string locationName)
    {
        SceneChangerEvent?.Invoke();
        PlayerPrefs.SetString("PrevousSceneName", PrevousSceneName);
        SceneManager.LoadScene(locationName);
    }
}
