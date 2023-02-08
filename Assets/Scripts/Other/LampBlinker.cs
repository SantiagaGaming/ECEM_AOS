using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlinker : BaseLamp
{
    private Color _greyColor;
    private bool _canBlink = true;
    private void Start()
    {
        CurrentColor = Color.yellow;
        _greyColor = Color.grey;
        GetComponent<Renderer>().material.color = _greyColor;
    }
    public override void EnableLamp(bool value)
    {
        EnableBlink(value);
    }
    public void EnableBlink(bool value)
    {
     _canBlink = value;
        StartCoroutine(Blink());
    }
    private IEnumerator Blink()
    {
        if(_canBlink)
        {
            int rnd = Random.Range(0, 2);
            GetComponent<Renderer>().material.color = rnd > 0 ? _greyColor : CurrentColor;
            yield return new WaitForSeconds(Random.Range(0, 1f));
            StartCoroutine(TagsHelper.BLINK);
        }
        else
        {
            GetComponent<Renderer>().material.color = _greyColor;
        }
    }
}
