using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private string _sceneName;
    private void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
        if (_sceneName != TagsHelper.MENU_LOCATION)
        {
            SceneSettings.Instance.Memory.PrevousLocation = SceneSettings.Instance.Memory.CurrentLocation;
            SceneSettings.Instance.Memory.CurrentLocation = _sceneName;
        }
    }
    public void TeleportToLocation(string locationName)
    {
        if (!SceneSettings.Instance.Memory.Teleport)
            return;

            if (locationName == TagsHelper.DSP_LOCATION||
            locationName == TagsHelper.RELAY_LOCATION ||
            locationName == TagsHelper.CROSS_LOCATION ||
            locationName == TagsHelper.DGA_LOCATION ||
            locationName == TagsHelper.FEED_LOCATION ||
            locationName == TagsHelper.FIELD_LOCATION ||
            locationName == TagsHelper.HALL1_LOCATION ||
            locationName == TagsHelper.HALL2_LOCATION ||
            locationName == TagsHelper.SHN_LOCATION ||
             locationName == TagsHelper.UVK_LOCATION)
            {
                if (_sceneName != locationName)
            {
                SceneManager.LoadScene(locationName);
            }
            
            }
            else if (locationName == TagsHelper.MENU_LOCATION &&
            _sceneName != TagsHelper.MENU_LOCATION )
            {
            SceneManager.LoadScene(locationName);
            }
            else if (locationName == TagsHelper.MENU_LOCATION &&
             _sceneName == TagsHelper.MENU_LOCATION)
        {
            SceneManager.LoadScene(SceneSettings.Instance.Memory.CurrentLocation);
            }
            else
            {
            API api = FindObjectOfType<API>();
                api.OnEndTweenInvoke(locationName);
            }
        }
           
    }

