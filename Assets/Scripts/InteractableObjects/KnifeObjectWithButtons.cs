using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeObjectWithButtons : BaseObject
{
    [SerializeField] private GameObject _knifeButtons;
    [SerializeField] private MovingButtonsController _movingButtonsController;


    public override void OnClicked(InteractHand interactHand)
    {
        MovingButtonsController.Instance.HideAllButtons();
        _knifeButtons.SetActive(true);

    }
    private void OnEnable()
    {
        _movingButtonsController.ButtonsPositionChanged += OnDisableKnifeButtons;
    }
    private void OnDisable()
    {
        _movingButtonsController.ButtonsPositionChanged -= OnDisableKnifeButtons;
    }
    private void OnDisableKnifeButtons()
    {
        _knifeButtons.SetActive(false);
    }
}
