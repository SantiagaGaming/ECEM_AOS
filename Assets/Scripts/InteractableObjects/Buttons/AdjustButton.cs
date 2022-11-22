using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdjustButton : MovingButton
{
    [SerializeField] private Hands _hand;
    private enum Hands
    {
        Hand,
        Hand_1,
        Hand_2  
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if(_hand ==Hands.Hand)
        {
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("hand");
            MovingButtonsController.Instance.PushPushableObject();
        }
        else if(_hand == Hands.Hand_1)
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("hand_1");
        else if (_hand == Hands.Hand_2)
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("hand_2");
    }
}
