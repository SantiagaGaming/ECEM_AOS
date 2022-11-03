using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenObject : MonoBehaviour
{
    [SerializeField] private string _screenName;

    public string GetScreenName()
    {
        return _screenName;
    }
    public void EnableScreenObject(bool value)
    {
        gameObject.SetActive(value);
    }
}
