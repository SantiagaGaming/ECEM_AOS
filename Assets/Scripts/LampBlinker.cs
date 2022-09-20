using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlinker : MonoBehaviour
{
    private Color _currentColor;
    private Color _greyColor;
    private LampBlinkController _LampBlinkcontroller;
    private void Start()
    {
        _currentColor = GetComponent<Renderer>().material.color;
        _greyColor = Color.gray;
        _LampBlinkcontroller = FindObjectOfType<LampBlinkController>();
        _LampBlinkcontroller.AddLampBlinker(this);
    }
    public void EnableBlink(bool value)
    {
        if (value)
            StartCoroutine("Blink");
        else
            StopCoroutine("Blink");

    }
    private IEnumerator Blink()
    {
        int rnd = Random.Range(0, 2);
        GetComponent<Renderer>().material.color = rnd > 0 ?  _greyColor : _currentColor;
        yield return new WaitForSeconds(Random.Range(0, 1f));
        StartCoroutine("Blink");
    }
}
