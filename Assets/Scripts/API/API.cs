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
    [AosEvent(name: "Перемещение игрока")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "Клик по кнопке далее")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnMeasure;
    [AosEvent(name: "Результат причины")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "Открыть меню")]
    public event AosEventHandler OnMenu;
    protected void Start()
    {
        Init();
    }
    protected virtual void Init()
    {

    }

    [AosAction(name: "Телепорт")]
    public void Teleport([AosParameter("Задать локацию для перемещения")] string location)
    {
        ControllersHandler.Instance.GetSceneChanger().TeleportToLocation(location);
            EndTween?.Invoke(location);
    }
    [AosAction(name: "Задать текст локации")]
    public virtual void showWelcome(JObject info, JObject nav)
    {
    }
    [AosAction(name: "Показать информацию отказа")]
    public virtual void showFaultInfo(JObject info, JObject nav)
    {
    }

    [AosAction(name: "Показать место")]
    public virtual void showPlace(JObject place, JArray data, JObject nav)
    {
        
    }
    [AosAction(name: "Обновить место")]
    public  virtual void updatePlace(JArray data)
    { 
    }
    [AosAction(name: "Показать реакцию")]
    public void showReaction(JObject info, JObject nav)
    {
        navAction?.Invoke("msgClose");
    }

    [AosAction(name: "Показать сообщение")]
    public virtual void showMessage(JObject info, JObject nav)
    {
    }
    [AosAction(name: "Показать сообщение")]
    public  virtual void showResult(JObject info, JObject nav)
    {
    }
    [AosAction(name: "Показать точки")]
    public virtual void showPoints(string info, JArray data)
    {
    }

    [AosAction(name: "Показать реакцию")]
    public virtual void showTime(string time)
    {
    }
    [AosAction(name: "Показать точки измерения")]
    public virtual void showMeasure(JArray measureDevices, JArray measurePoints)
    {
    }
    [AosAction(name: "Показать результат измерения")]
    public virtual void showMeasureResult(JObject temp, JObject temp1)
    {
    }

    [AosAction(name: "Показать меню")]
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
