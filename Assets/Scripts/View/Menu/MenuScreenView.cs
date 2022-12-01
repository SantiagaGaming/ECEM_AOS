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
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;


    private string _currentScreenName;

    public void SetTimertext(string text)
    {
        _timertext.text = text;
    }
    public void SetOtkazText(string text)
    {
        _commentText.text= text;
    }

    public void SetExitText(string text)
    {
        _exitText.text = text;
    }
    public void SetWarnText(string text)
    {
        _warnText.text = text;
    }

    public void ActivateMenuScreen(string name)
    {
        DeactivateAllScreens();
        var tempMenuScreen = _menuScreens.FirstOrDefault(n => n.GetScreenName() == name);
        tempMenuScreen.EnableScreenObject(true);
        _currentScreenName = name;
    }
    private void DeactivateAllScreens()
    {
        foreach (var screen in _menuScreens)
        {
            screen.EnableScreenObject(false);
        }
    }
    public string GetCurrentScreenName()
    {
        return _currentScreenName;
    }

}
