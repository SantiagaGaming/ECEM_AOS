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
            sceneAosObject.InvokeOnClick();
        ControllersHandler.Instance.GetBackButtonsHandler().SetBackButtonObject(_backButton);
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
;
    }

}