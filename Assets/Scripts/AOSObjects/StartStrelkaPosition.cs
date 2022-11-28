using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Strelka")]

public class StartStrelkaPosition : AosObjectBase
{
    [AosAction(name: "Проиграть анимацию плюс")]
    public void PlayPlusAnim()
    {
        PlayerPrefs.SetString("Strelka", "minus");
    }
    [AosAction(name: "Проиграть анимацию минус")]
    public void PlayMinusAnim()
    {
        PlayerPrefs.SetString("Strelka", "plus");
    }
}
