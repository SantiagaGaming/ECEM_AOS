using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class TriggerObject : MonoBehaviour
{
    [SerializeField] private GameObject _anotherCollider;
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
            _anotherCollider.GetComponent<Collider>().enabled = true;
            GetComponent<Collider>().enabled = false;
        }
        }
}
