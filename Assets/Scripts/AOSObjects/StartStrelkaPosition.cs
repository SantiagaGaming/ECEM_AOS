using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Strelka")]

public class StartStrelkaPosition : AosObjectBase
{
    public void PlayRockEngineMinusAnim()
    {
        PlayerPrefs.SetString("Strelka", "minus");
    }
    [AosAction(name: "Проиграть анимацию Камень двигатель плюс")]
    public void PlayRockEnginePlusAnim()
    {
        PlayerPrefs.SetString("Strelka", "plus");
    }
}
