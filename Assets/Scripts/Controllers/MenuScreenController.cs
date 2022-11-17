using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenController : MonoBehaviour
{
    [SerializeField] private MenuScreenView _menuScreenView;
    private string _tempMenuScreenObject;

    public static MenuScreenController Instance;
    private void Awake()
    {
        if(Instance ==null)
        Instance = this;
    }

    public void EnableMenuScreen(string value)
    {
        if(value !="back")
        {
           _menuScreenView.ActivateMenuScreen(value);
            _tempMenuScreenObject = value;
        }
       
        else
        {
           if(_menuScreenView.GetCurrentLocationName()== "otkazInfo"|| _menuScreenView.GetCurrentLocationName() == "otkazi"|| _menuScreenView.GetCurrentLocationName() == "exit")
            {
                _menuScreenView.ActivateMenuScreen("main");
            }
           else if(_menuScreenView.GetCurrentLocationName() == "uvk"||
                    _menuScreenView.GetCurrentLocationName() == "field" ||
                    _menuScreenView.GetCurrentLocationName() == "feed" ||
                _menuScreenView.GetCurrentLocationName() == "dsp"||
                _menuScreenView.GetCurrentLocationName() == "relay")
            {
                _menuScreenView.ActivateMenuScreen("otkazi");
            }
        }
    }
}
