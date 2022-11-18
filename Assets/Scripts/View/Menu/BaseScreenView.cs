using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreenView : MonoBehaviour
{
    [SerializeField] private string _screenName;

    [HideInInspector]public Canvas Canvas;
    public void ActivateScreen(bool value)
    {
    Canvas = GetComponentInChildren<Canvas>();
        if (Canvas != null)
            Canvas.enabled = value;
    }
    public string GetScreenName { get => _screenName;}
}
