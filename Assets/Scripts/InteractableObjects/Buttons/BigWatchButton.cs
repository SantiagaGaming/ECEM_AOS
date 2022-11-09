using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWatchButton : BaseButton
{w
    [SerializeField] private PlayerToMenuAndArmTeleportController _menuArmController;

    public override void OnClicked(InteractHand interactHand)
    {
        if(MovingButtonsController.Instance.CurrentBaseObject!=null&&
            MovingButtonsController.Instance.CurrentBaseObject.GetComponent<ArmMenuTeleporter>() != null)
        {
           
        }
    }
}
