using AosSdk.Core.Player.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingButton : BaseButton
{
    [SerializeField] protected string actionText;
    public override void OnHoverIn(InteractHand interactHand)
    {
        transform.localScale *= 1.5f;
        if (helperPos != null)
        {
            string temptext = $"{actionText} {MovingButtonsController.Instance.ObjectHelperName}";
            canvasHelper.ShowTextHelper(temptext, helperPos);
        }  
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        transform.localScale /= 1.5f;
        if (helperPos != null)
            canvasHelper.HidetextHelper();
    }
}
