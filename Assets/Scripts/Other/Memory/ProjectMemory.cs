using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "DevelopSettings", menuName = "DevelopSettings", order = 1)]
public class ProjectMemory : ScriptableObject
{
    [SerializeField] private InputActionProperty _menuAction;
    [HideInInspector] public bool StrelkPosition { get; set; }
    [HideInInspector] public bool Stone { get; set; } 
    [HideInInspector] public bool Teleport { get; set; } 
    [HideInInspector] public string PrevousLocation { get; set; }
    [HideInInspector] public string CurrentLocation { get; set; }
    [HideInInspector] public string LocationText { get; set; }
    [HideInInspector] public bool ScpuBroken { get; set; } 
    [HideInInspector] public int LampLights { get; set; }
    [HideInInspector] public bool QfCondition { get; set; }
    [HideInInspector] public bool DspShvuKey0 { get; set; }
    [HideInInspector] public bool DspShvuKey3 { get; set; }
    [HideInInspector] public int KnifePosition { get; set; }
    [HideInInspector] public bool Monitor1 { get; set; }
    [HideInInspector] public bool Monitor1Enabler { get; set; }
    [HideInInspector] public bool Monitor2 { get; set; }
    [HideInInspector] public bool Monitor2Enabler { get; set; }
    [HideInInspector] public bool Monitor3 { get; set; }
    [HideInInspector] public bool Monitor3Enabler { get; set; }
    [HideInInspector] public Dictionary<string,int> UvkLights { get; set; }

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
