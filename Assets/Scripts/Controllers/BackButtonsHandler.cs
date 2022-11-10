using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonsHandler : MonoBehaviour
{
    public static BackButtonsHandler Instance;
    private BackButtonObject _currentBackButton;
    public string ActionToInvoke { get; set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
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
            _currentBackButton.EnableButton(value);
    }

}
