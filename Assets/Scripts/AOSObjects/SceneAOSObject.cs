using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "AosObject")]
public class SceneAOSObject : AosObjectBase
{
    [AosEvent(name: "OnClickObject")]
    public event AosEventHandlerWithAttribute OnClickObject;
    public void InvokeOnClick()
    {
        CurrentAOSObject.Instance.SceneAosObject = this;
        OnClickObject?.Invoke(ObjectId);
    }
    public void ActionWithObject(string actionName)
    {
        OnClickObject?.Invoke(actionName);
    }
}
