using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneObjectWithButton : ObjectWithButton
{
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        GetComponent<MeshRenderer>().enabled = value;
    }

}
