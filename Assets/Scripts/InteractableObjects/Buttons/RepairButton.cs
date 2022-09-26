using AosSdk.Core.Player.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepairButton : MovingButton
{

    public override void OnClicked(InteractHand interactHand)
    {
        MovingButtonsController.Instance.PlayRepairAnimation();
    }
}