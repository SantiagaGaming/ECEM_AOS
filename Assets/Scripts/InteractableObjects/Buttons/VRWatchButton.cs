using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRWatchButton : BaseButton
{
    public override void OnClicked(InteractHand interactHand)
    {
      SceneChanger changer = FindObjectOfType<SceneChanger>();
        changer.OnTeleportToLocation("menu");
    }
}
