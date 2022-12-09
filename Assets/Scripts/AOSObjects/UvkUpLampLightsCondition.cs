using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "UvkUpLampLights")]

public class UvkUpLampLightsCondition : AosObjectBase
{
    [AosAction(name: "Сменить состояние объекта true - активен, false - неактивен")]
    public void SetCondition(int condition)
    {
        SceneSettings.Instance.Memory.LampLights = condition;
        UvkUpLampLights uvkUpLampLights = FindObjectOfType<UvkUpLampLights>();
        if (uvkUpLampLights != null)
            uvkUpLampLights.SetLampCondition();
    }
}
