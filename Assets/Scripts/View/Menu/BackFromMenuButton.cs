using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFromMenuButton : BaseButton
{
    [SerializeField] private EscButton _escButton;
    public override void OnClicked(InteractHand interactHand)
    {
        _escButton.OnShowMenu();
    }
}
