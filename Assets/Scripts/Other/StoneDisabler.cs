using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDisabler : MonoBehaviour
{
    [SerializeField] private HandButton _handButton;
    private void Start()
    {
        if (PlayerPrefs.GetString("Stone") == "false")
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }

    private void OnEnable()
    {
        _handButton.ButtonNumberEvent += OnDisableStone;
    }
    private void OnDisable()
    {
        _handButton.ButtonNumberEvent -= OnDisableStone;
    }
    private void OnDisableStone(int value)
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        PlayerPrefs.SetString("Stone", "false");
    }
}
