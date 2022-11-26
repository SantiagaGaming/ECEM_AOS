using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class BackButtonObject : BaseButton
{
    public UnityAction BackButtonClickEvent;
    [SerializeField] private string _locationBackName;
    [SerializeField] private BackTriggerObject _backTriggerObj;
    [SerializeField] private BackButtonObject _parentArmButton;
    protected override void Start()
    {
        base.Start();
        BackButtonsHandler.Instance.AddBackButton(this);
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if(AOSColliderActivator.Instance.UVKDoor)
        {
            base.OnClicked(interactHand);
            if (AOSColliderActivator.Instance.CanTouch)
            {
                BackButtonClickEvent?.Invoke();
                MovingButtonsController.Instance.HideAllButtons();
                API api = FindObjectOfType<API>();
                api.InvokeNavActionBack(BackButtonsHandler.Instance.ActionToInvoke);
                //ShupController shup = FindObjectOfType<ShupController>();
                //shup.ResetShupPosition();
                BackButtonsHandler.Instance.SetBackButtonObject(null);
                if (_backTriggerObj != null)
                    _backTriggerObj.EnableBackTriggerObject(false);
                if (_parentArmButton != null)
                    BackButtonsHandler.Instance.SetBackButtonObject(_parentArmButton);
            }
        }
 

    }
    public override void EnableButton(bool value)
    {
        base.EnableButton(value);
        if (_backTriggerObj != null)
        {
            _backTriggerObj.EnableBackTriggerObject(true);
            _backTriggerObj.SetButtonInvoke(this);
        }
    }
}
