using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class VrEscButton : BaseButton
{
    public override void OnClicked(InteractHand interactHand)
    {
       EscButton esc = FindObjectOfType<EscButton>();
        if (esc != null)
            esc.OnShowMenu();
    }
}
