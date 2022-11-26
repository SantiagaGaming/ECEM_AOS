using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbtcDoorAnimation : BaseAnimationObject
{
    public override void PlayScritableAnimtaion()
    {
        if (CanRotate && CanOpen)
        {
            StartCoroutine(RotateDoor(IsClosed));
            IsClosed = IsClosed ? false : true;
        }
}

    private IEnumerator RotateDoor(bool value)
    {
        CanRotate = false;
        if (value)
        {
            GetComponent<Collider>().enabled = false;
            int y = -197;
            while (y <= -50)
            {
                transform.localRotation = Quaternion.Euler(-90, y, 17.137f);
                y++;
                yield return new WaitForSeconds(0.01f);
            }
        }

        else
        {
            MovingButtonsController.Instance.HideAllButtons();

            int y = -50;
            while (y >= -197)
            {
                transform.localRotation = Quaternion.Euler(-90, y, 17.137f);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
        }
        CanRotate = true;
  
    }
}