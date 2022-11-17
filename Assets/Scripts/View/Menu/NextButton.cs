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

    private Button _button;

    private int _index;
    private void OnEnable()
    {
        _api.NextButtonStateChangedEvent += OnChangeIndexValue;
    }
    private void OnDisable()
    {
        _api.NextButtonStateChangedEvent -= OnChangeIndexValue;
    }
    private void Start()
    {
        _button= GetComponent<Button>();
        _button.onClick.AddListener(ButtonAction);
    }
    private void ButtonAction()
    {
        if(_index==0)
        {
            NextButtonClickedEvent?.Invoke("next");
        }
        else if(_index==1)
        {
            NextButtonClickedEvent?.Invoke("start");
        }
        else if (_index == 2)
        {
            //_buttonText.text = "Выход";
            NextButtonClickedEvent?.Invoke("finish");
        }
    }
    public void OnChangeIndexValue()
    {
        _index++;
    }
    



}


