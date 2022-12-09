using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "ScpuCondition")]
public class QfCondition : AosObjectBase
{
    [AosAction(name: "Задать состояние модуля сцпу - сломан")]
    public void UpQf()
    {
        SceneSettings.Instance.Memory.QfCondition = true;
    }
}
