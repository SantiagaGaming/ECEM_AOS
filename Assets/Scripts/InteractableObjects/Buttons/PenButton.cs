using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenButton : MovingButton
{
    public override void OnClicked(InteractHand interactHand)
    {
        CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("pen");
    }
}
