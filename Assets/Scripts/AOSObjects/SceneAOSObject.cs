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
    [AosEvent(name: "EndTween")]
    public event AosEventHandlerWithAttribute EndTween;
    protected BaseObject baseObject;
    [SerializeField] private bool _button;
    [SerializeField] private bool _place;

    public void InvokeOnClick()
    {
        OnClickObject?.Invoke(ObjectId);
    }

    [AosAction("Вкл. Выкл. Коллайдер объекта")]
    public void ActivateObjectCollider([AosParameter("Включение коллайдера")] bool active)
    {
        Collider col = gameObject.GetComponent<Collider>();
        if (col != null && !_button)
            col.enabled = active;
    }
    public void ActionWithObject(string actionName)
    {
        OnClickObject?.Invoke(actionName);
    }

}
