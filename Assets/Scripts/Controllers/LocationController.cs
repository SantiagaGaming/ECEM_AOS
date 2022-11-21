using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationController : MonoBehaviour
{
    private string _locationName;
    public static LocationController instance;
    private void Awake()
    {
        if(instance==null)
            instance = this;
    }
    private void Start()
    {
        _locationName = SceneManager.GetActiveScene().name;
    }
    public string LocationName => _locationName;

}
