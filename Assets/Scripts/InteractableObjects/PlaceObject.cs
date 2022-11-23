using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.Core.PlayerModule.Pointer;

public class PlaceObject : BaseObject
{

    [SerializeField] private BackButtonObject _backButton;

    public override void OnClicked(InteractHand interactHand)
    {
        IScriptableAnimationObject scriptableAnimationObject = GetComponent(typeof(IScriptableAnimationObject)) as IScriptableAnimationObject;
        if(scriptableAnimationObject!=null)
        {
            scriptableAnimationObject.PlayScritableAnimtaion();
        }
            BackButtonsHandler.Instance.SetBackButtonObject(_backButton);
            sceneAosObject.InvokeOnClick();
    }
    private void OnEnable()
    {
        if(_backButton!=null)
        _backButton.BackButtonClickEvent += OnBackClick;
    }
    private void OnDisable()
    {
        if (_backButton != null)
            _backButton.BackButtonClickEvent -= OnBackClick;
    }
    private void OnBackClick()
    {
        IScriptableAnimationObject scriptableAnimationObject = GetComponent(typeof(IScriptableAnimationObject)) as IScriptableAnimationObject;
        if (scriptableAnimationObject != null)
        {
            scriptableAnimationObject.PlayScritableAnimtaion();
        }
        BackButtonObject tempBackButton = BackButtonsHandler.Instance.GetCurrentBackButton();
        if(tempBackButton!=null)
        tempBackButton.EnableButton(false);
    }

}