using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Strelka")]

public class StartStrelkaPosition : AosObjectBase
{
    [AosAction(name: "��������� �������� ����")]
    public void PlayPlusAnim()
    {
        SceneSettings.Instance.Memory.StrelkPosition = true;
    }
    [AosAction(name: "��������� �������� �����")]
    public void PlayMinusAnim()
    {
        SceneSettings.Instance.Memory.StrelkPosition = false;
    }
}
