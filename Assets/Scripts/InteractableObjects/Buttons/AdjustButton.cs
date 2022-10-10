using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdjustButton : MovingButton
{

    public override void OnClicked(InteractHand interactHand)
    {
        MovingButtonsController.Instance.PlayPushAnimation();
    }
}
