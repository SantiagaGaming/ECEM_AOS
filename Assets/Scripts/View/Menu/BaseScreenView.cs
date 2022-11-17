using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreenView : MonoBehaviour
{
    [SerializeField] private string _screenName;
    public void ActivateScreen(bool value)
    {
        gameObject.SetActive(value);
    }
    public string GetScreenName { get => _screenName;}
}
