using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "DevelopSettings", menuName = "DevelopSettings", order = 1)]
public class DevelopSettings : ScriptableObject
{
    [SerializeField]
    public bool Develop;
    [SerializeField] private InputActionProperty _menuAction;
    public UnityAction MenuEvent;
    private void OnEnable()
    {
        if(_menuAction!=null)
        _menuAction.action.performed += OnMenu;
    }
    private void OnDisable()
    {
        if (_menuAction != null)
            _menuAction.action.performed -= OnMenu;
    }
    private void OnMenu(InputAction.CallbackContext c)
    {
        MenuEvent?.Invoke();

    }
}
