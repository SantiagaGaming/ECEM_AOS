using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "AosObject")]
public class SceneAosObject : AosObjectBase
{
    [AosEvent(name: "OnClickObject")]
    public event AosEventHandlerWithAttribute OnClickObject;
    protected BaseObject baseObject;
    [SerializeField] private bool _button;
    [SerializeField] private bool _place;
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
