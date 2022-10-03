using AosSdk.Core.Player.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnifeSwitchButton : BaseButton
{
    [SerializeField] private int _position;
    public UnityAction<int>KnifeButtonClicked;
    public override void OnClicked(InteractHand interactHand)
    {
        KnifeButtonClicked?.Invoke(_position);
    }
}
