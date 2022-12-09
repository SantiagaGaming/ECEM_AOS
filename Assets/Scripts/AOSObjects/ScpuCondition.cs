using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "ScpuCondition")]

public class ScpuCondition : AosObjectBase
{
    [AosAction(name: "������ ��������� ������ ���� - ������")]
    public void BrokeScpu()
    {
        SceneSettings.Instance.Memory.ScpuBroken = true;
    }
}
