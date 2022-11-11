using AosSdk.Core.PlayerModule.Pointer;
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
        KnifeSwitch knife = FindObjectOfType<KnifeSwitch>();
        knife.ChangeKnifePosition(_position);
    }
}
