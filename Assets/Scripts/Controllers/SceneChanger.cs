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

    private void Start()
    {
            if (AOSColliderActivator.Instance.DevelopMode())
            {
                foreach (var door in _teleportDoors)
                {
                    door.DoorClickedEvent += OnTeleportToLocation;
                }
            }
        if (SceneManager.GetActiveScene().name != "Menu")
            PrevousSceneName = SceneManager.GetActiveScene().name;

    }
    public void OnTeleportToLocation(string locationName)
    {
        SceneChangerEvent?.Invoke();
        if (SceneManager.GetActiveScene().name != "Menu")
            PlayerPrefs.SetString("PrevousSceneName", PrevousSceneName);
        SceneManager.LoadScene(locationName);
    }
}
