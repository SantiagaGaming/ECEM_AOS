using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public UnityAction SceneChangerEvent;
    public UnityAction PlaceChangedEvent;
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
        if (locationName == "dsp" ||
            locationName == "relay" ||
            locationName == "cross" ||
            locationName == "dga" ||
            locationName == "feed" ||
            locationName == "field" ||
            locationName == "hall1" ||
            locationName == "hall2" ||
            locationName == "shn" ||
             locationName == "uvk")
        {
            SceneManager.LoadScene(locationName);

        }
        else
        {
            API api = FindObjectOfType<API>();
            api.OnInvokeEndTween(locationName);
        }

    }
}
