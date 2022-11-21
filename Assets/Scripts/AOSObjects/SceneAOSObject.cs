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
        OnClickObject?.Invoke(ObjectId);
    }
}
