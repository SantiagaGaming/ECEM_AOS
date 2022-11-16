using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class TriggerObject : BaseObject
{
    [SerializeField] private string _locationName;
    [SerializeField] private SceneAosObject _exitObject;

    public override void OnClicked(InteractHand interactHand)
    {
        return;
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        return;
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        return;
    }

        private void OnTriggerEnter(Collider col)
        {
            var aosObject = col.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
                return;
        sceneAosObject = GetComponent<SceneAosObject>();
        if (sceneAosObject != null)
        {
            sceneAosObject.InvokeOnClick();
        }

     
    }

}
