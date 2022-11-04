using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NextButtonState
{
    Start,
    Fault
}

public class NextButton : BaseButton
{
    
    [SerializeField] private API _api;
    public NextButtonState CurrentState;

    public override void OnClicked(InteractHand interactHand)
    {
        if(CurrentState == NextButtonState.Start)
        _api.NextButtonClicked("next");
        else if(CurrentState == NextButtonState.Fault)
            _api.NextButtonClicked("start");
    }
}


