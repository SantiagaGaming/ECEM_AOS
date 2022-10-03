using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSwitchButtonsController : MonoBehaviour
{
    [SerializeField] private KnifeSwitchButton _leftButton;
    [SerializeField] private KnifeSwitchButton _rightButton;
    [SerializeField] private KnifeSwitchButton _idleButton;
    [SerializeField] private KnifeSwitch _knifeSwitch;

    private void OnEnable()
    {
        _leftButton.KnifeButtonClicked += OnSwtchKnife;
        _idleButton.KnifeButtonClicked += OnSwtchKnife;
        _rightButton.KnifeButtonClicked += OnSwtchKnife;
    }
    private void OnDisable()
    {
        _leftButton.KnifeButtonClicked -= OnSwtchKnife;
        _idleButton.KnifeButtonClicked -= OnSwtchKnife;
        _rightButton.KnifeButtonClicked -= OnSwtchKnife;
    }
    private void OnSwtchKnife(int position)
    {
        _knifeSwitch.ChangeKnifePosition(position);
    }
}
