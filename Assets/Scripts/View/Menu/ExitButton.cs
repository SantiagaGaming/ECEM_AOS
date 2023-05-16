using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : BaseButton
{
    [SerializeField] private API _api;
    public override void OnClicked(InteractHand interactHand)
    {
        _api = FindObjectOfType<API>();
        _api.OnNavActionInvoke(TagsHelper.EXIT);
    }
}
