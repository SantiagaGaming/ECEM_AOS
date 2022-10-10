using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.Core.PlayerModule.Pointer;

public class ExitButton : BaseButton
{

    public override void OnClicked(InteractHand interactHand)
    {
        Application.Quit();
    }
}
