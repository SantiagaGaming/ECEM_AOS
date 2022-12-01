using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDisabler : MonoBehaviour
{
    [SerializeField] private MovingButtonWithAction _handButton;
    private void Start()
    {
        if (!SceneSettings.Instance.Memory.Stone)
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
        SceneSettings.Instance.Memory.Stone = false;
    }
}
