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
    private string _sceneName;

    private void Start()
    {
            if (AOSColliderActivator.Instance.DevelopMode())
            {
                foreach (var door in _teleportDoors)
                {
                    door.DoorClickedEvent += OnTeleportToLocation;
                }
            }
        _sceneName = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name != "menu")
        {
            PlayerPrefs.SetString("CurrentSceneName", _sceneName);
        }
    }
    public void OnTeleportToLocation(string locationName)
    {
        if(PlayerPrefs.GetString("Teleport")!="false")
        {
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
                PrevousSceneName = _sceneName;
                PlayerPrefs.SetString("PrevousSceneName", PrevousSceneName);
                if (PrevousSceneName != locationName)
                    SceneManager.LoadScene(locationName);
            }
            else if (locationName == "menu" &&
            _sceneName != "start" &&
            _sceneName != "menu")
            {
                Debug.Log("PlayerPrefs is not  menu " + PlayerPrefs.GetString("PrevousSceneName"));
                SceneManager.LoadScene(locationName);
            }
            else if (locationName == "menu" &&
            _sceneName != "start" &&
             _sceneName == "menu")
            {
                SceneManager.LoadScene(PlayerPrefs.GetString("CurrentSceneName"));
            }
            else
            {
                API api = FindObjectOfType<API>();
                api.OnInvokeEndTween(locationName);
            }
        }
           
    }
}
