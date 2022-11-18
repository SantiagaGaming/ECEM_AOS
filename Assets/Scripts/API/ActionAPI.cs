using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAPI : API
{
    protected override void Start()
    {
        LocationName = LocationController.instance.LocationName;
        base.Start();
        OnInvokeEndTween();
    }
    public override void showPlace(JObject place, JArray data, JObject nav)
    {
        Debug.Log(place.SelectToken("apiId").ToString()+ "FromShowPlace");
        string location = place.SelectToken("apiId").ToString();
        if (place.SelectToken("name") != null)
        {
            string locationText = place.SelectToken("name").ToString();
            PlayerPrefs.SetString("Location", locationText);
        }
        else Debug.Log("����");
        AOSColliderActivator.Instance.DeactivateAllColliders();
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("apiId");
            if (temp != null)
            {
                AOSColliderActivator.Instance.ActivateColliders(temp.ToString(), item.SelectToken("name").ToString());
            }
        }
        if (nav.SelectToken("back") != null && nav.SelectToken("back").SelectToken("action") != null && nav.SelectToken("back").SelectToken("action").ToString() != String.Empty)
        {
            Debug.Log("in nav");
            //BackButtonsHandler.Instance.EnableCurrentBackButton(true);
            //BackButtonsHandler.Instance.ActionToInvoke = nav.SelectToken("back").SelectToken("action").ToString();
        }
        //StreetCollidersActivator.Instance.ActivateColliders(place.SelectToken("apiId").ToString());
    }
    public override void updatePlace(JArray data)
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
    public override void showPoints(string info, JArray data)
    {
        foreach (JObject item in data)
        {
            if (item != null)
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
    public override void showMeasure(JArray measureDevices, JArray measurePoints)
    {
        //MeasureButtonsBag.Instance.CurrentButtonsNames = new List<string>();
        //foreach (JObject item in measurePoints)
        //{
        //    var tmpArray = item.SelectToken("points");
        //    if (tmpArray != null && tmpArray is JArray)
        //    {
        //        foreach (JObject item2 in tmpArray)
        //        {
        //            MeasureButtonsBag.Instance.CurrentButtonsNames.Add(item2.SelectToken("apiId").ToString());
        //        }
        //    }
        //}
    }
}
