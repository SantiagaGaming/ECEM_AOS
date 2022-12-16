using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class BackButtonObject : BaseButton
{
    public UnityAction BackButtonClickEvent;

    [SerializeField] private BackTriggerObject _backTriggerObj;
    [SerializeField] private BackButtonObject _parentArmButton;
    protected override void Start()
    {
        base.Start();
        ControllersHandler.Instance.GetBackButtonsHandler().AddBackButton(this);
    }
    public override void OnClicked(InteractHand interactHand)
    {
             base.OnClicked(interactHand);
            if (SceneSettings.Instance.CanTouch)
            {
                BackButtonClickEvent?.Invoke();
                MovingButtonsController.Instance.HideAllButtons();
                API api = FindObjectOfType<API>();
                api.OnNavActionInvoke(ControllersHandler.Instance.GetBackButtonsHandler().ActionToInvoke);
                ControllersHandler.Instance.GetBackButtonsHandler().SetBackButtonObject(null);
                if (_backTriggerObj != null)
                    _backTriggerObj.EnableBackTriggerObject(false);
                if (_parentArmButton != null)
                    ControllersHandler.Instance.GetBackButtonsHandler().SetBackButtonObject(_parentArmButton);
        }
    }
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        if (_backTriggerObj != null)
        {
            _backTriggerObj.EnableBackTriggerObject(true);
            _backTriggerObj.SetButtonInvoke(this);
        }
    }

}
