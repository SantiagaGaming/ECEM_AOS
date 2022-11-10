using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.Core.PlayerModule.Pointer;

public class BaseObjectWithAnimation : BaseObject
{

    [SerializeField] private BaseObject[] _objects;
    [SerializeField] private BackButtonObject _backButton;

    public override void OnClicked(InteractHand interactHand)
    {
        IScriptableAnimationObject scriptableAnimationObject = GetComponent(typeof(IScriptableAnimationObject)) as IScriptableAnimationObject;
        CurrentAOSObject.Instance.IScriptObject = scriptableAnimationObject;
        scriptableAnimationObject.PlayScritableAnimtaion();
        if (AOSColliderActivator.Instance.DevelopMode())
            OnActivateObjectsInPlace(true);
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
        if (AOSColliderActivator.Instance.DevelopMode())
        {
            OnActivateObjectsInPlace(false);
            IScriptableAnimationObject scriptableAnimationObject = GetComponent(typeof(IScriptableAnimationObject)) as IScriptableAnimationObject;
            scriptableAnimationObject.PlayScritableAnimtaion();
        }
       
    }

    private void OnActivateObjectsInPlace(bool value)
    {
        if (AOSColliderActivator.Instance.DevelopMode()&& _objects!=null)
        {
            foreach (var item in _objects)
            {
                item.EnableObject(value);
            }
        }
    }
}