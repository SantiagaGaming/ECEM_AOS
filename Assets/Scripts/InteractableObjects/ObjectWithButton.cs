using AosSdk.Core.Player.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : BaseObject
{

    [SerializeField] private Transform _buttonsPos;
    [SerializeField] private bool _vertical;
    [SerializeField] private MovebleObject _movingObject;
    [SerializeField] private PushableObject _pushableObject;
    [SerializeField] private bool _bigWatch;

    public override void OnClicked(InteractHand interactHand)
    {
   
            base.OnClicked(interactHand);

            if (_buttonsPos == null && !_vertical)
                MovingButtonsController.Instance.SetMovingButtonsPosition(transform.position + new Vector3(0f, 0.12f, 0));
            else if (_buttonsPos == null && _vertical)
                MovingButtonsController.Instance.SetMovingButtonsPosition(transform.position + new Vector3(0.09f, 0.05f, 0));
            else
                MovingButtonsController.Instance.SetMovingButtonsPosition(_buttonsPos.position);
            MovingButtonsController.Instance.ObjectHelperName = helperName;
            MovingButtonsController.Instance.ObjectName = gameObject.name;
        MovingButtonsController.Instance.HideAllButtons();
        if (!_bigWatch)

            MovingButtonsController.Instance.ShowAllButtons();
        else
            MovingButtonsController.Instance.ShowBigWatchButton();

        if (_movingObject == null)
                _movingObject = GetComponent<MovebleObject>();
            if (_movingObject != null)
            {
                MovingButtonsController.Instance.SetMovingObject(_movingObject);
            }
            else
            {
                MovingButtonsController.Instance.SetMovingObject(null);
                MovingButtonsController.Instance.HideRepairButton();
            }
        if (_pushableObject == null)
            _pushableObject = GetComponent<PushableObject>();
        if (_pushableObject != null)
        {
            MovingButtonsController.Instance.SetPushableObject(_pushableObject);
            MovingButtonsController.Instance.HideRepairButton();
        }
        else
        {
            MovingButtonsController.Instance.SetPushableObject(null);
        }
    }


}

