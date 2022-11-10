using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class SchemeButton : BaseButton
{
    [SerializeField] private SchemeImageChanger _schemeChanger;
    [SerializeField] private BackButtonObject _backButtonObject;
    private void OnEnable()
    {
        _backButtonObject.BackButtonClickEvent += OnDisableMap;
    }
    private void OnDisable()
    {
        _backButtonObject.BackButtonClickEvent -= OnDisableMap;
    }

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if (_schemeChanger.GetCondition())
        {
            _schemeChanger.EnableImage(false);
        }
        else _schemeChanger.EnableImage(true);
    }
    private void OnDisableMap()
    {
        _schemeChanger.EnableImage(false);
    }
}
