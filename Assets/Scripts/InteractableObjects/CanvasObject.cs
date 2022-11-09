using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
public class CanvasObject : BaseObject
{
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
    }

    public override void OnHoverIn(InteractHand interactHand)
    {
        base.OnHoverIn(interactHand);
        transform.localScale *= 2f;

    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        base.OnHoverOut(interactHand);
        transform.localScale /= 2f;
    }
    public void DisableButton()
    {
        gameObject.SetActive(false);
    }

}
