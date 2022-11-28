using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenView : BaseScreenView
{

    [SerializeField] private MenuScreenObject[] _menuScreens;
    [SerializeField] private TextMeshProUGUI _currentLocationText;
    [SerializeField] private TextMeshProUGUI _timertext;


    private string _locationName;

    public void SetLocationText()
    {
        PlayerPrefs.GetString("Location");
    }
    public void SetTimertext(string text)
    {
        _timertext.text = text;
    }

    public void ActivateMenuScreen(string name)
    {
        DeactivateAllObjects();
        var tempMenuScreen = _menuScreens.FirstOrDefault(n => n.GetScreenName() == name);
        tempMenuScreen.EnableScreenObject(true);
        _locationName = name;
    }
    private void DeactivateAllObjects()
    {
        foreach (var item in _menuScreens)
        {
            item.EnableScreenObject(false);
        }
    }
    public string GetCurrentLocationName()
    {
        return _locationName;
    }

}
