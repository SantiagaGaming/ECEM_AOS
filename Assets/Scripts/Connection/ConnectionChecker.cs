using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[AosSdk.Core.Utils.AosObject(name: "�������")]
public class ConnectionChecker : AosObjectBase
{
    [AosEvent(name: "����� � �����������")]
    public event AosEventHandlerWithAttribute OnReadyToAction;
    [SerializeField] private API _api;
    public void OnConnect()
    {
        OnReadyToAction.Invoke("Ready to Action");
        if(_api!=null)
        _api.OnInvokeEndTween("Start");
        else
        {
            _api = FindObjectOfType<API>();
            _api.OnInvokeEndTween(_api.LocationName);
        }
    }


}
