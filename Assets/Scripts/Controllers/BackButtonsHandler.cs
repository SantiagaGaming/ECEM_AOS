using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonsHandler : MonoBehaviour
{

    private BackButtonObject _currentBackButton;
    private List<BackButtonObject> _backButtons = new List<BackButtonObject>();
    public string ActionToInvoke { get; set; }
    public void SetBackButtonObject(BackButtonObject backButtonObject)
    {
        _currentBackButton = backButtonObject;
    }
    public BackButtonObject GetCurrentBackButton()
    {
        if (_currentBackButton != null)
            return _currentBackButton;
        else return null;
    }
    public void EnableCurrentBackButton(bool value)
    {
        if (_currentBackButton != null)
            _currentBackButton.EnableObject(value);
    }
    public void AddBackButton(BackButtonObject backButton)
    {
        _backButtons.Add(backButton);
    }
    public void DeactivateAllBackButtons()
    {
        foreach (var item in _backButtons)
        {
            item.EnableObject(false);
        }
    }

}
