using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsWithButton : ObjectWithButton
{
    [SerializeField] private Transform _reactionHelerPosition;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);

        if (_reactionHelerPosition != null)
            ControllersHandler.Instance.GetReactionHelper().ChangeReactionHelperPosition(_reactionHelerPosition);
    }
}
