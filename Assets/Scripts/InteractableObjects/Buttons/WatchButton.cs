using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WatchButton : MovingButton
{

    public override void OnClicked(InteractHand interactHand)
    {
        CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("eye");
    }
}
