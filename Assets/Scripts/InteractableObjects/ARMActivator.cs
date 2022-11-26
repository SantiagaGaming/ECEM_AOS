using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMActivator : BaseObject
{
    [SerializeField] private Canvas _arm;
    [SerializeField] private BackButtonObject _backButton;
    
    public override void OnClicked(InteractHand interactHand)
    {
      _arm.enabled= true;
        BackButtonsHandler.Instance.GetCurrentBackButton().EnableButton(false);
        BackButtonsHandler.Instance.SetBackButtonObject(_backButton);
        sceneAosObject.InvokeOnClick();
        BackButtonsHandler.Instance.EnableCurrentBackButton(true);
    }
    private void OnEnable()
    {
        if (_backButton != null)
            _backButton.BackButtonClickEvent += OnBackClick;
    }
    private void OnDisable()
    {
        if (_backButton != null)
            _backButton.BackButtonClickEvent -= OnBackClick;
    }
    private void OnBackClick()
    {
        BackButtonObject tempBackButton = BackButtonsHandler.Instance.GetCurrentBackButton();
        if (tempBackButton != null)
            tempBackButton.EnableButton(false);
    }
}
