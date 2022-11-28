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
        PlayerPrefs.SetString("Strelka", "minus");
    }
    [AosAction(name: "��������� �������� �����")]
    public void PlayMinusAnim()
    {
        PlayerPrefs.SetString("Strelka", "plus");
    }
}
