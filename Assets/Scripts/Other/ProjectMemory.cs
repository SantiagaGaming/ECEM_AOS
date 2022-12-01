using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "DevelopSettings", menuName = "DevelopSettings", order = 1)]
public class ProjectMemory : ScriptableObject
{
    [SerializeField] private InputActionProperty _menuAction;
    [HideInInspector] public bool StrelkPosition { get; set; } = true;
    [HideInInspector] public bool Stone { get; set; } = false;
    [HideInInspector] public bool Teleport { get; set; } = false;
    [HideInInspector] public string PrevousLocation { get; set; }
    [HideInInspector] public string CurrentLocation { get; set; } = "Start";
    [HideInInspector] public string LocationText { get; set; }

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
