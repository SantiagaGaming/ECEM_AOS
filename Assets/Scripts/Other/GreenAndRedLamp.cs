using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenAndRedLamp : BaseLamp
{
    private void Start()
    {
        CurrentColor = GetComponent<Renderer>().material.color;
    }
    public override void EnableLamp(bool value)
    {
        GetComponent<Renderer>().enabled = value;

    }
}
