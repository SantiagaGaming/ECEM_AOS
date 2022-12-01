using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[AosSdk.Core.Utils.AosObject(name: "API")]
public class API : AosObjectBase
{
    [AosEvent(name: "����������� ������")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "���� �� ������ �����")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "��������� ���������")]
    public event AosEventHandlerWithAttribute OnMeasure;
    [AosEvent(name: "��������� �������")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "������� ����")]
    public event AosEventHandler OnMenu;
    protected void Start()
    {
        Init();
    }
    protected virtual void Init()
    {

    }

    [AosAction(name: "��������")]
    public void Teleport([AosParameter("������ ������� ��� �����������")] string location)
    {
        ControllersHandler.Instance.GetSceneChanger().TeleportToLocation(location);
            EndTween?.Invoke(location);
    }
    [AosAction(name: "������ ����� �������")]
    public virtual void showWelcome(JObject info, JObject nav)
    {
    }
    [AosAction(name: "�������� ���������� ������")]
    public virtual void showFaultInfo(JObject info, JObject nav)
    {
    }

    [AosAction(name: "�������� �����")]
    public virtual void showPlace(JObject place, JArray data, JObject nav)
    {
        
    }
    [AosAction(name: "�������� �����")]
    public  virtual void updatePlace(JArray data)
    { 
    }
    [AosAction(name: "�������� �������")]
    public void showReaction(JObject info, JObject nav)
    {
        navAction?.Invoke("msgClose");
    }

    [AosAction(name: "�������� ���������")]
    public virtual void showMessage(JObject info, JObject nav)
    {
    }
    [AosAction(name: "�������� ���������")]
    public  virtual void showResult(JObject info, JObject nav)
    {
    }
    [AosAction(name: "�������� �����")]
    public virtual void showPoints(string info, JArray data)
    {
    }

    [AosAction(name: "�������� �������")]
    public virtual void showTime(string time)
    {
    }
    [AosAction(name: "�������� ����� ���������")]
    public virtual void showMeasure(JArray measureDevices, JArray measurePoints)
    {
    }
    [AosAction(name: "�������� ��������� ���������")]
    public virtual void showMeasureResult(JObject temp, JObject temp1)
    {
    }

    [AosAction(name: "�������� ����")]
    public virtual void showMenu(JObject faultInfo, JObject exitInfo,JObject resons)
    {
    }
    public void OnNavActionInvoke(string value)
    {
        navAction?.Invoke(value);
    }

    public void OnReasonInvoke(string name)
    {
        OnReason?.Invoke(name);
    }
    public void OnMenuInvoke()
    {
        OnMenu?.Invoke();
    }
    public void OnEndTweenInvoke(string location)
    {
        EndTween?.Invoke(location);
    }

}
