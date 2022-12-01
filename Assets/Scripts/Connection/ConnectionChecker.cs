using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[AosSdk.Core.Utils.AosObject(name: "Connection")]
public class ConnectionChecker : AosObjectBase
{
    [AosEvent(name: "Ready to Action")]
    public event AosEventHandlerWithAttribute OnReadyToAction;
    [SerializeField] private API _api;
    public void OnConnect()
    {
        OnReadyToAction.Invoke("Ready to Action");
        if(_api!=null)
        _api.OnEndTweenInvoke(SceneSettings.Instance.LocationName);
    }


}
