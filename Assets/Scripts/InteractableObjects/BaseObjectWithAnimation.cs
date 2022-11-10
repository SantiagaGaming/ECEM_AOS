using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.Core.PlayerModule.Pointer;

public class BaseObjectWithAnimation : BaseObject
{

    [SerializeField] private GameObject[] _colliderObjects;

    public override void OnClicked(InteractHand interactHand)
    {
        IScriptableAnimationObject scriptableAnimationObject = GetComponent(typeof(IScriptableAnimationObject)) as IScriptableAnimationObject;
        scriptableAnimationObject.PlayScritableAnimtaion();
    }
}