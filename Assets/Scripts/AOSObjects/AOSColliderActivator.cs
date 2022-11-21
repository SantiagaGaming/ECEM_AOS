using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AOSColliderActivator : MonoBehaviour
{
    public static AOSColliderActivator Instance;

    [SerializeField] private DevelopSettings _settings;
    private bool _isDevelopment;
    private List<BaseObject> _aosSceneObjects = new List<BaseObject>();
    public bool CanTouch { get; set; } = true;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        _isDevelopment = _settings.Develop;
    }
    public void AddBaseObject(BaseObject obj)
    {
        _aosSceneObjects.Add(obj);
    }

    public void ActivateColliders(string objectName, string text)
    {
        foreach (var item in _aosSceneObjects)
        {
            if (item.GetAOSName() == objectName)
            {
                item.EnableObject(true);
                item.SetHelperName(text);
            }

        }
    }
    public void DeactivateAllColliders()
    {
        foreach (var item in _aosSceneObjects)
        {
            item.EnableObject(false);
        }
    }
    public bool DevelopMode()
    {
        return _isDevelopment;
    }
    public DevelopSettings Settings => _settings;


}
