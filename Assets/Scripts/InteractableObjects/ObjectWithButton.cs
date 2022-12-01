using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : BaseObject
{
    [SerializeField] private Transform _buttonsPos;
    [SerializeField] private bool _vertical;
    [SerializeField] private RepairableObject _movingObject;
    private PushableObject _pushableObject;

    public override void OnClicked(InteractHand interactHand)
    {
            base.OnClicked(interactHand);
        if(SceneSettings.Instance.CanTouch)
        {
            if (_buttonsPos == null && !_vertical)
                MovingButtonsController.Instance.SetMovingButtonsPosition(transform.position + new Vector3(0f, 0.12f, 0), this);
            else if (_buttonsPos == null && _vertical)
                MovingButtonsController.Instance.SetMovingButtonsPosition(transform.position + new Vector3(0.09f, 0.05f, 0), this);
            else
                MovingButtonsController.Instance.SetMovingButtonsPosition(_buttonsPos.position, this);
            MovingButtonsController.Instance.ObjectHelperName = helperName;

            _pushableObject = GetComponent<PushableObject>();
            if (_pushableObject != null)
                MovingButtonsController.Instance.SetPushObject(_pushableObject);
            else MovingButtonsController.Instance.SetPushObject(null);

            if (_movingObject != null)
                MovingButtonsController.Instance.SetToolObject(_movingObject);
            else MovingButtonsController.Instance.SetToolObject(null);
        }
          

    }


}

