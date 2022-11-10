using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioButton : BaseButton
{
    [SerializeField] private BackButtonObject _backButton;
    [SerializeField] protected Transform _dietPosition;
    private bool _radio = false;
    private void OnEnable()
    {
        _backButton.BackButtonClickEvent += OnBackClicked;
    }
    private void OnDisable()
    {
        _backButton.BackButtonClickEvent -= OnBackClicked;
    }
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        DietEnabler();
    }
    private void DietEnabler()
    {
        if (!_radio) _radio = true;
        else _radio = false;
        Diet.Instance.EnableDiet(_radio, _dietPosition);
    }
    private void OnBackClicked()
    {
        if (_radio)
        {
            _radio = false;
            Diet.Instance.EnableDiet(_radio, _dietPosition);
        }

    }
}


