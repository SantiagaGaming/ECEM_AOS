using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Test")]
public class AOSTest : AosObjectBase
{

    [AosAction(name: "Проиграть анимацию Камень двигатель минус")]
    public void Play()
    {
        Debug.Log("Sucess");
    }
}
