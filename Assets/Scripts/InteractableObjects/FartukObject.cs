using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartukObject : BaseObject
{
    private bool _side = true;
    private bool _canRotate = true;
    public override void OnClicked(InteractHand interactHand)
    {
        if (_canRotate)
        {
            StartCoroutine(RoofRotator(_side));
            if (_side)
                _side = false;
            else _side = true;
        }
    }
    private IEnumerator RoofRotator(bool value)
    {
        if (value)
        {
            int x = 0;
            while (x <= 90)
            {
               transform.localRotation = Quaternion.Euler(x, 0, 0);
                x++;
                yield return new WaitForSeconds(0.001f);
            }
        }
        else
        {
            int x = 90;
            while (x >= 0)
            {
                transform.localRotation = Quaternion.Euler(x, 0, 0);
                x--;
                yield return new WaitForSeconds(0.001f);
            }
        }

    }
}
