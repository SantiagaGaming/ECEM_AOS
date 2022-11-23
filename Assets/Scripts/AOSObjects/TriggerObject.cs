using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class TriggerObject : MonoBehaviour
{
    [SerializeField] private string _locationName;
    [SerializeField] private SceneAosObject _exitObject;
    private SceneAosObject sceneAosObject;
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
    private void OnTriggerExit(Collider col)
    {
            var aosObject = col.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
                return;
            if (_exitObject != null)
                _exitObject.InvokeOnClick();
    }
}
