using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    [SerializeField] private API _api;
    public UnityAction <string> NextButtonClickedEvent;
    private string _actionOnButton;

    private Button _button;

    private void Start()
    {
        _button= GetComponent<Button>();
        _button.onClick.AddListener(ButtonAction);
    }
    private void ButtonAction()
    {
        NextButtonClickedEvent?.Invoke(_actionOnButton);
    }
    public void ChangeActionOnButton(string value)
    {
        _actionOnButton= value;
    }
    



}


