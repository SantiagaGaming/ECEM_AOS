using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingButtonWithAction : MovingButton
{
    public UnityAction<int> ButtonNumberEvent;
    [SerializeField] private ButtonActionName _currentAction;
    private enum ButtonActionName
    {
        Hand,
        Hand_1,
        Hand_2,
        Eye,
        Tool,
        Tool_1,
        Pen,
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (_currentAction == ButtonActionName.Hand)
        {
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("hand");
            MovingButtonsController.Instance.PlayPushAnimation();
            ButtonNumberEvent?.Invoke(1);
        }
        else if (_currentAction == ButtonActionName.Hand_1)
        {
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("hand_1");
            ButtonNumberEvent?.Invoke(0);
        }

        else if (_currentAction == ButtonActionName.Hand_2)
        {
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("hand_2");
            ButtonNumberEvent?.Invoke(2);
        }
        else if (_currentAction == ButtonActionName.Eye)
        {
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("eye");
        }

        else if (_currentAction == ButtonActionName.Tool)
        {
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("tool");
            MovingButtonsController.Instance.PlayToolAnimation();
        }
        else if (_currentAction == ButtonActionName.Tool_1)
        {
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("tool_1");
            MovingButtonsController.Instance.PlayToolAnimation();
        }
        else if (_currentAction == ButtonActionName.Pen)
        {
            CurrentAOSObject.Instance.SceneAosObject.ActionWithObject("pen");
        }

    }

}
