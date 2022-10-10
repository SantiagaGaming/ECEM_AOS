using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;

public class Door : BaseObject
{
    public UnityAction<Transform, string> TeleportToObjectEvent;
    public UnityAction AosTeleportEvent;
    [SerializeField] private Transform _newPlayerPosition;


    public void StartTeleporting()
    {
        TeleportToObjectEvent?.Invoke(_newPlayerPosition, gameObject.name);
        AosTeleportEvent?.Invoke();
    }
    override public void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        StartTeleporting();

    }
}
