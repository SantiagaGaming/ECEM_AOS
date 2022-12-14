using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlinker : MonoBehaviour
{
    private Color _currentColor;
    private Color _greyColor;
    private void Start()
    {
        _currentColor = Color.yellow;
        _greyColor = Color.black;
    }
    public void EnableBlink(bool value)
    {
        if (value)
            StartCoroutine(TagsHelper.BLINK);
        else
            StopCoroutine(TagsHelper.BLINK);

    }
    public void DisableBlink()
    {
        GetComponent<Renderer>().material.color = _greyColor;
    }
    private IEnumerator Blink()
    {
        int rnd = Random.Range(0, 2);
        GetComponent<Renderer>().material.color = rnd > 0 ?  _greyColor : _currentColor;
        yield return new WaitForSeconds(Random.Range(0, 1f));
        StartCoroutine(TagsHelper.BLINK);
    }
}
