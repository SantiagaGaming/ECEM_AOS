using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;

public class TeleportDoor : BaseObject
{
    public UnityAction<string> DoorClickedEvent;
    [SerializeField] private string _locationName;

    public void StartTeleporting()
    {
        if(AOSColliderActivator.Instance.DevelopMode())
        DoorClickedEvent?.Invoke(_locationName);
    }
    override public void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        StartTeleporting();

    }
}
