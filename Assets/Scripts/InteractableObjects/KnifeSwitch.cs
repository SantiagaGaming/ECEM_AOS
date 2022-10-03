using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSwitch : MonoBehaviour
{
    public void ChangeKnifePosition(int position)
    {
        if(position ==0)
           transform.localRotation = Quaternion.Euler(0, 0, 0);
        else if(position ==1)
            transform.localRotation = Quaternion.Euler(0, 0, -45);
        else if(position ==2)
            transform.localRotation = Quaternion.Euler(0, 0, 45);

    }
}
