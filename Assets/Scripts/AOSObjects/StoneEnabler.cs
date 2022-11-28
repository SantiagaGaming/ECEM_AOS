using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "Левый камень")]
public class StoneEnabler : AosObjectBase
{
    [AosAction(name: "Сменить состояние объекта true - активен, false - неактивен")]
    public void SetCondition(bool value)
    {
        if (value == true)
            PlayerPrefs.SetString("Stone", "true");
        else
            PlayerPrefs.SetString("Stone", "false");
    }
}
