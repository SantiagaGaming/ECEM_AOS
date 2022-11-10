using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;

[AosSdk.Core.Utils.AosObject(name: "Стрелка")]

public class StrelkaAOS : AosObjectBase
    
{
    [AosEvent(name: "Попытка перевода стрелки в плюс")]
    public event AosEventHandler OnSwitchStrelkaPlus;
    [AosEvent(name: "Попытка перевода стрелки в Минус")]
    public event AosEventHandler OnSwitchStrelkaMinus;
    [AosEvent(name: "Из плюса в минус")]
    public event AosEventHandler FromPlusToMinus;
    [AosEvent(name: "Из минуса в плюс")]
    public event AosEventHandler FromMinusToPlus;
    public void TrySwitchStrelkaPlus()
    {
        OnSwitchStrelkaPlus?.Invoke();
    }
    public void TrySwitchStrelkaMinus()
    {
        OnSwitchStrelkaMinus?.Invoke();
    }
    public void StrelkaFromPlusTominus()
    {
        FromPlusToMinus?.Invoke();
    }
    public void StrelkaFromMinusToPlus()
    {
        FromMinusToPlus?.Invoke();
    }
}
