using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "MonitorEnabler")]

public class MonitorEnabler : SceneAosObject
{
    [AosAction(name: "������� ��������� �������")]
    public void SetCondition(bool condition)
    {
        SceneSettings.Instance.Memory.Monitor1Enabler = condition;
    }

    [AosAction(name: "������� ��������� �������")]
    public void EnableMonitor(bool condition)
    {
        SceneSettings.Instance.Memory.Monitor1 = condition;
    }
}

