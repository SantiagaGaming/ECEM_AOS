using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NextButton : BaseButton
{
    public UnityAction <string> NextButtonClickedEvent;
    private string _actionOnButton;

    public override void OnClicked(InteractHand interactHand)
    {
        NextButtonClickedEvent?.Invoke(_actionOnButton);
    }
    public void ChangeActionOnButton(string value)
    {
        _actionOnButton= value;
    }
    public void EnableButton(bool value)
    {
      gameObject.SetActive(value);
    }
}


