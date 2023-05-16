using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class BaseButton : BaseObject
{
     private float _localScale = 1.2f;
     public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
    }

    public override void OnHoverIn(InteractHand interactHand)
    {
        base.OnHoverIn(interactHand);
        transform.localScale *= _localScale;

    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        base.OnHoverOut(interactHand);
        transform.localScale /= _localScale;
    }

}