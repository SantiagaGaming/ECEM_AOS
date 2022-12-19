using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.Core.PlayerModule.Pointer;

public class PlaceObject : BaseObject
{

    [SerializeField] private BackButtonObject _backButton;
    [SerializeField] private Transform _reactionHelerPosition;

    public override void OnClicked(InteractHand interactHand)
    {
        MovingButtonsController.Instance.HideAllButtons();
        ControllersHandler.Instance.GetReactionHelper().EnableReactionHelper(false);
        ControllersHandler.Instance.GetReactionHelper().ChangeReactionHelperText("");
        IScriptableAnimationObject scriptableAnimationObject = GetComponent(typeof(IScriptableAnimationObject)) as IScriptableAnimationObject;
        if(scriptableAnimationObject!=null)
        {
            scriptableAnimationObject.PlayScritableAnimtaion();
        }
            sceneAosObject.InvokeOnClick();

        if (_reactionHelerPosition != null)
            ControllersHandler.Instance.GetReactionHelper().ChangeReactionHelperPosition(_reactionHelerPosition);
        else
            ControllersHandler.Instance.GetReactionHelper().ChangeReactionHelperPosition(transform);
        ControllersHandler.Instance.GetBackButtonsHandler().SetBackButtonObject(_backButton);
        EnableOutlines(false);
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