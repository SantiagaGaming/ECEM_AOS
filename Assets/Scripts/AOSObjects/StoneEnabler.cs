using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "����� ������")]
public class StoneEnabler : AosObjectBase
{
    [AosAction(name: "������� ��������� ������� true - �������, false - ���������")]
    public void SetCondition(bool value)
    {
        if (value == true)
            PlayerPrefs.SetString("Stone", "true");
        else
            PlayerPrefs.SetString("Stone", "false");
    }
}
