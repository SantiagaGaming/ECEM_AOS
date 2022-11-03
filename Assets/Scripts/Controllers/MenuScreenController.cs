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
           if(_menuScreenView.GetCurrentLoactionName()== "otkazInfo"|| _menuScreenView.GetCurrentLoactionName() == "otkazi"|| _menuScreenView.GetCurrentLoactionName() == "exit")
            {
                _menuScreenView.ActivateMenuScreen("main");
            }
           else if(_menuScreenView.GetCurrentLoactionName() == "uvk"||
                    _menuScreenView.GetCurrentLoactionName() == "field" ||
                    _menuScreenView.GetCurrentLoactionName() == "feed" ||
                _menuScreenView.GetCurrentLoactionName() == "dsp"||
                _menuScreenView.GetCurrentLoactionName() == "relay")
            {
                _menuScreenView.ActivateMenuScreen("otkazi");
            }
        }
    }
}
