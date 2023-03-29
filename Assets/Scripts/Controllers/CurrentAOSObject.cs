using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentAOSObject : MonoBehaviour
{
    public static CurrentAOSObject Instance;
    private CurrentAOSObject() { }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public SceneAOSObject SceneAosObject { get; set; }
}
