using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OtkazButton : BaseButton
{
    private API _api;
    public override void OnClicked(InteractHand interactHand)
    {
        _api = FindObjectOfType<API>();
        _api.OnReasonInvoke(gameObject.name);
    }
}
