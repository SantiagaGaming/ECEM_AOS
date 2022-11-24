using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartukAnimation : BaseAnimationObject
{

    public override void PlayScritableAnimtaion()
    {
        if (CanRotate && CanOpen)
        {
            StartCoroutine(RoofRotator(IsClosed));
        
        }
    }
    private IEnumerator RoofRotator(bool value)
    {
        AOSColliderActivator.Instance.CanTouch = false;
        CanRotate = false;
        if (value)
        {
            GetComponent<Collider>().enabled= false;
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
            GetComponent<Collider>().enabled = true;
        }
        CanRotate = true;
        IsClosed = IsClosed ? false : true;
        AOSColliderActivator.Instance.CanTouch = true;

    }
}
