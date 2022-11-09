using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFadeIn : MonoBehaviour
{
    public bool FadeStart = true;
    private void Update()
    {

        if (FadeStart)
        {
            Player.Instance.FadeIn(1f, true);
            StartCoroutine(Delay());
        }
        else
            Player.Instance.FadeOut(1f, false);


    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        FadeStart = false;
    }
}
