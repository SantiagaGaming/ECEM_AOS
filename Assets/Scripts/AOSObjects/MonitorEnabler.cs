using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "MonitorEnabler")]

public class MonitorEnabler : AosObjectBase
{
    [AosAction(name: "Сменить состояние объекта")]
    public void SetCondition(bool condition)
    {
        SceneSettings.Instance.Memory.Monitor1Enabler = condition;
     }
}

