using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;

public class ExitButton : BaseButton
{

    public override void OnClicked(InteractHand interactHand)
    {
        Application.Quit();
    }
}
