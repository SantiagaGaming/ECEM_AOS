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
        SceneSettings.Instance.Memory.StrelkPosition = true;
    }
    [AosAction(name: "Проиграть анимацию минус")]
    public void PlayMinusAnim()
    {
        SceneSettings.Instance.Memory.StrelkPosition = false;
    }
}
