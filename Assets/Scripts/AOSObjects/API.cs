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

[AosSdk.Core.Utils.AosObject(name: "Место с телепортом")]
public class API : AosObjectBase
{
   // [SerializeField] private Teleporter _teleporter;
    [SerializeField] private StartScreenController _startScreenController;
    [SerializeField] private LastScreenController _lastScreenController;
    [SerializeField] private LocationTextController _locationTextController;
    [SerializeField] private NextButton _nextButton;
    [SerializeField] private TimerView _timer;
    [SerializeField] private PointerDevice _pointerDevice;
    [SerializeField] private MenuTextView _menuTextView;
    [AosEvent(name: "Перемещение игрока")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "Клик по кнопке далее")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnMeasure;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "Открыть меню")]
    public event AosEventHandler OnMenu;
    private string _measuretext;
    private string _type;
    private string _blackValue;
    private string _redValue;
    private string _pointerValue;
    public void NextButtonClicked(string value)
    {
        navAction.Invoke(value);
    }

    public void SetLocation()
    {
        EndTween?.Invoke(_locationTextController.GetLocationName());
    }
    public void Teleport([AosParameter("Задать локацию для перемещения")] string location)
    {
       // _teleporter.StartTeleport(location);
        EndTween?.Invoke(location);
        Debug.Log(location + " EndTween");
    }
    [AosAction(name: "Задать текст локации")]
    public void showWelcome(JObject info, JObject nav)

    {
        _startScreenController.EnableStartScteen(true);
        _startScreenController.SetHeaderText(info.SelectToken("name").ToString());
        _startScreenController.SetCommentText(info.SelectToken("text").ToString());
        _startScreenController.SetButtonText(nav.SelectToken("ok").SelectToken("caption").ToString());
        //_nextButton.CurrentState = NextButtonState.Start;
    }

    [AosAction(name: "Показать место")]
    public void showPlace(JObject place, JArray data, JObject nav)

    {
        Debug.Log(place.SelectToken("apiId").ToString());
        string location = place.SelectToken("apiId").ToString();
        _locationTextController.SetLocationT(location);
        if (place.SelectToken("name") != null)
            _locationTextController.SetLocationText(place.SelectToken("name").ToString());
        else Debug.Log("нету");
      //  _teleporter.StartTeleport(location);
        Debug.Log("Enter UpdatePlace");
        AOSColliderActivator.Instance.DeactivateAllColliders();
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("apiId");
            if (temp != null)
            {
                AOSColliderActivator.Instance.ActivateColliders(temp.ToString(), item.SelectToken("name").ToString());
            }

        }
        if (nav.SelectToken("back")!= null && nav.SelectToken("back").SelectToken("action")!=null && nav.SelectToken("back").SelectToken("action").ToString() != String.Empty)
        {
                Debug.Log("in nav");
                //BackButtonsHandler.Instance.EnableCurrentBackButton(true);
                //BackButtonsHandler.Instance.ActionToInvoke = nav.SelectToken("back").SelectToken("action").ToString();
        }

        //StreetCollidersActivator.Instance.ActivateColliders(place.SelectToken("apiId").ToString());
    }
    [AosAction(name: "Обновить место")]
    public void updatePlace(JArray data)
    {
        Debug.Log("Enter UpdatePlace");
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("points");
            if (temp != null)
            {
                //Diet diet = FindObjectOfType<Diet>();
                //diet.EnablePlusOrMinus(null);
                if (temp is JArray)
                {
                    foreach (var temp2 in temp)
                    {
                        //diet.EnablePlusOrMinus(temp2.SelectToken("apiId").ToString());
                    }
                }
            }
        }
    }

    [AosAction(name: "Показать информацию отказа")]
    public void showFaultInfo(JObject info, JObject nav)

    {
        _startScreenController.SetHeaderText(info.SelectToken("name").ToString());
        _startScreenController.SetCommentText(info.SelectToken("text").ToString());
        _startScreenController.SetButtonText(nav.SelectToken("ok").SelectToken("caption").ToString());
        //_nextButton.CurrentState = NextButtonState.Fault;

    }
    [AosAction(name: "Показать реакцию")]
    public void showReaction(JObject info, JObject nav)
    {
        //InfoCanvas.Instance.SetInfoText(info.SelectToken("text").ToString());
        navAction?.Invoke("msgClose");
    }

    [AosAction(name: "Показать сообщение")]
    public void showMessage(JObject info, JObject nav)
    {
        _lastScreenController.ShowMessageScreen();
        _lastScreenController.SetHeaderText(info.SelectToken("name").ToString());
        _lastScreenController.SetCommentText(info.SelectToken("text").ToString());
        Debug.Log("in showMessage");
    }
    [AosAction(name: "Показать сообщение")]
    public void showResult(JObject info, JObject nav)
    {
        _lastScreenController.ShowLastScreen();
        _lastScreenController.SetHeaderText(info.SelectToken("name").ToString());
        _lastScreenController.SetCommentText(info.SelectToken("text").ToString());
        Debug.Log("in Result");
    }
    [AosAction(name: "Показать точки")]
    public void showPoints(string info, JArray data)
    {
        foreach (JObject item in data)
        {
            if(item!=null)
            {
                if (item.SelectToken("tool") != null && item.SelectToken("name") != null)
                {
                    if (item.SelectToken("tool").ToString() == "eye")
                    {
                        MovingButtonsController.Instance.ShowWatchButton();
                        MovingButtonsController.Instance.SetWatchButtonText(item.SelectToken("name").ToString());
                    }
                    if (item.SelectToken("tool").ToString() == "hand")
                    {
                        MovingButtonsController.Instance.ShowAdjustButton();
                        MovingButtonsController.Instance.SetAdjustButtonText(item.SelectToken("name").ToString());
                    }
                    if (item.SelectToken("tool").ToString() == "repair")
                    {
                        MovingButtonsController.Instance.ShowRepairButton();
                        MovingButtonsController.Instance.SetRepairButtonText(item.SelectToken("name").ToString());
                    }
                }
                else if (item.SelectToken("apiId") != null)
                {
                    Debug.Log("Sucess");
                    string buttonName = item.SelectToken("apiId").ToString();
                    Debug.Log(item.SelectToken("apiId").ToString() + "RADIO");
                    //Diet diet = FindObjectOfType<Diet>();
                    //diet.EnablePlusOrMinus(buttonName);
                }
            }
        }
    }

    [AosAction(name: "Показать реакцию")]
    public void showTime(string time)
    {
      _timer.ShowTimerText(time);
        Debug.Log(time + "таймер");
    }
    [AosAction(name: "Показать точки измерения")]
    public void showMeasure(JArray measureDevices, JArray measurePoints)
    {
        MeasureButtonsBag.Instance.CurrentButtonsNames= new List<string>();
       foreach (JObject item in measurePoints)
            {
                var tmpArray = item.SelectToken("points");
                if (tmpArray != null && tmpArray is JArray)
                {
                    foreach (JObject item2 in tmpArray)
                    {
                        MeasureButtonsBag.Instance.CurrentButtonsNames.Add(item2.SelectToken("apiId").ToString());
                    }
                }
            }
        }
    [AosAction(name: "Показать точки измерения")]
    public void showMeasureResult(JObject result, JObject nav)
    {
        float measureValue = float.Parse(result.SelectToken("result").ToString());
        _pointerValue = _pointerDevice.SetValue(measureValue);
        _measuretext = $"measure_device:{_type}:{_blackValue}:{_redValue}:{_pointerValue}";
        OnMeasure?.Invoke(_measuretext);
    }
    [AosAction(name: "Показать меню")]
    public void showMenu(JObject faultInfo, JObject exitInfo,JObject resons)
    {
        _menuTextView.SetHeaderText(faultInfo.SelectToken("name").ToString());
        _menuTextView.SetInfoText(faultInfo.SelectToken("text").ToString());
        _menuTextView.SetExitSureText(exitInfo.SelectToken("quest").ToString());
        if (exitInfo.SelectToken("text") != null)
            _menuTextView.SetExitText(HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString()));
        if(exitInfo.SelectToken("warn")!=null)
        _menuTextView.SetWarnText(HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString()));
    }


    public void ReturnMeasureText()
    {
        _pointerValue = null;
        if(_type != null && _blackValue != null && _redValue != null)
        {
            _measuretext = $"measure_device:{_type}:{_blackValue}:{_redValue}:{_pointerValue}";
            OnMeasure?.Invoke(_measuretext);
        }
        else
        {
            _pointerDevice.SetValue(0);
            _measuretext = $"measure_device:{_type}:{_blackValue}:{_redValue}:{_pointerValue}";
            OnMeasure?.Invoke(_measuretext);
        }
    }
    public void FinishEvent()
    {
        navAction.Invoke("finish");
    }
    public void ExitEvent()
    {
        navAction.Invoke("exit");
    }
    public void InvokeNavActionBack(string value)
    {
        navAction?.Invoke(value);
    }
    public void SetTypeText(string type)
    {
        _type = type;
        ReturnMeasureText();
    }
    public void SetRedText(string red)
    {
        _redValue = red;
        ReturnMeasureText();
    }
    public void SetBlackText(string black)
    {
        _blackValue = black;
        ReturnMeasureText();
    }
    public void OnReasonInvoke(string name)
    {
        OnReason?.Invoke(name);
    }
    public void OnMenuInvoke()
    {
        OnMenu?.Invoke();
    }

}
