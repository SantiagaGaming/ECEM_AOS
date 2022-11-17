using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    public UnityAction <string> NextButtonClickedEvent;

    private Button _button;

    private int _index;
    private void Start()
    {
        _button= GetComponent<Button>();
        _button.onClick.AddListener(ButtonAction);
    }
    private void ButtonAction()
    {
        if(_index==0)
        {
            //_buttonText.text = "Далее";
            NextButtonClickedEvent?.Invoke("next");
        }
        else if(_index==1)
        {
            //_buttonText.text = "Начать";
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


