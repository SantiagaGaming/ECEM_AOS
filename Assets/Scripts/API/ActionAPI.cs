using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionAPI : API
{
    protected override void Init()
    {
        StartCoroutine(EndTweenDelay());
    }
    private IEnumerator EndTweenDelay()
    {
        yield return new WaitForSeconds(0.2f);
        OnEndTweenInvoke(SceneSettings.Instance.LocationName);
    }

    public override void showPlace(JObject place, JArray data, JObject nav)
    {

        BackButtonObject tempBackButton = ControllersHandler.Instance.GetBackButtonsHandler().GetCurrentBackButton();
        if (tempBackButton != null)
            tempBackButton.EnableObject(false);
        string location = place.SelectToken(TagsHelper.API_ID).ToString();
        if (place.SelectToken(TagsHelper.NAME) != null)
        {
            string locationText = place.SelectToken(TagsHelper.NAME).ToString();
            SceneSettings.Instance.Memory.LocationText = locationText;
        }
        ControllersHandler.Instance.GetAOSColliderActivator().DeactivateAllColliders();
        ControllersHandler.Instance.GetAOSImageContainer().DeactivateAllImages();

        foreach (JObject item in data)
        {
            var baseObject = item.SelectToken(TagsHelper.API_ID);
            if (baseObject != null)
            {
                ControllersHandler.Instance.GetAOSColliderActivator().ActivateColliders(baseObject.ToString(), item.SelectToken(TagsHelper.NAME).ToString());
            }
            if (item.SelectToken(TagsHelper.VIEW) != null && ControllersHandler.Instance.GetSceneChanger() != null)
            {
                var aosObjectWithImage = item.SelectToken(TagsHelper.VIEW);
                if (aosObjectWithImage != null)
                {
                    if (aosObjectWithImage.SelectToken(TagsHelper.API_ID) != null)
                    {
                        string name = aosObjectWithImage.SelectToken(TagsHelper.API_ID).ToString();
                        AOSObjectWithImage tempObj = ControllersHandler.Instance.GetAOSImageContainer().GetAOSObjectWithImage(name);
                        if (tempObj != null)
                        {
                            tempObj.EnableObject(name);
                        }
                    }
                }
            }
        }
        if (nav.SelectToken(TagsHelper.BACK) != null && nav.SelectToken(TagsHelper.BACK).SelectToken(TagsHelper.ACTION) != null && nav.SelectToken(TagsHelper.BACK).SelectToken(TagsHelper.ACTION).ToString() != String.Empty)
        {
            ControllersHandler.Instance.GetBackButtonsHandler().EnableCurrentBackButton(true);
            ControllersHandler.Instance.GetBackButtonsHandler().ActionToInvoke = nav.SelectToken(TagsHelper.BACK).SelectToken(TagsHelper.ACTION).ToString();
        }
    }
    public override void updatePlace(JArray data)
    {
        foreach (JObject item in data)
        {
            var points = item.SelectToken(TagsHelper.POINTS);
            if (points != null)
            {
                Diet diet = FindObjectOfType<Diet>();
                diet.EnablePlusOrMinus(null);
                if (points is JArray)
                {
                    MovingButtonsController.Instance.HideAllButtons(); 
                    foreach (var point in points)
                    {
                        diet.EnablePlusOrMinus(point.SelectToken(TagsHelper.API_ID).ToString());
                        if (point.SelectToken(TagsHelper.TOOL) != null)
                        {
                            if (point.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.HAND)
                            {
                                MovingButtonsController.Instance.ShowHandButton();
                                MovingButtonsController.Instance.SetHandButtonText(point.SelectToken(TagsHelper.NAME).ToString());
                            }

                            if (point.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.HAND_1)
                            {
                                MovingButtonsController.Instance.ShowHand1Button();
                                MovingButtonsController.Instance.SetHand1ButtonText(point.SelectToken(TagsHelper.NAME).ToString());
                            }
                            if (point.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.HAND_2)
                            {
                                MovingButtonsController.Instance.ShowHand2Button();
                                MovingButtonsController.Instance.SetHand2ButtonText(point.SelectToken(TagsHelper.NAME).ToString());
                            }
                        }
            
                    }
                }
            }
        }
    }

    public override void showPoints(string info, JArray data)
    {
        MovingButtonsController.Instance.HideAllButtons();
        foreach (JObject button in data)
        {
            if (button != null)
            {
                MovingButtonsEnabler(button);
                if (button.SelectToken(TagsHelper.API_ID) != null)
                {
                    string buttonName = button.SelectToken(TagsHelper.API_ID).ToString();
                    Diet diet = FindObjectOfType<Diet>();
                    diet.EnablePlusOrMinus(buttonName);
                }
            }
        }
    }
    private void MovingButtonsEnabler(JObject button)
    {

        if (button.SelectToken(TagsHelper.TOOL) != null && button.SelectToken(TagsHelper.NAME) != null)
        {

            if (button.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.EYE)
            {
                MovingButtonsController.Instance.ShowWatchButton();
                MovingButtonsController.Instance.SetWatchButtonText(button.SelectToken(TagsHelper.NAME).ToString());
            }
            if (button.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.HAND)
            {
                MovingButtonsController.Instance.ShowHandButton();
                MovingButtonsController.Instance.SetHandButtonText(button.SelectToken(TagsHelper.NAME).ToString());
            }

            if (button.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.HAND_1)
            {
                MovingButtonsController.Instance.ShowHand1Button();
                MovingButtonsController.Instance.SetHand1ButtonText(button.SelectToken(TagsHelper.NAME).ToString());
            }
            if (button.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.HAND_2)
            {
                MovingButtonsController.Instance.ShowHand2Button();
                MovingButtonsController.Instance.SetHand2ButtonText(button.SelectToken(TagsHelper.NAME).ToString());
            }
            if (button.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.TOOL)
            {
                MovingButtonsController.Instance.ShowRepairButton();
                MovingButtonsController.Instance.SetRepairButtonText(button.SelectToken(TagsHelper.NAME).ToString());
            }
            if (button.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.TOOL_1)
            {
                MovingButtonsController.Instance.ShowRepair1Button();
                MovingButtonsController.Instance.SetRepair1ButtonText(button.SelectToken(TagsHelper.NAME).ToString());
            }
            if (button.SelectToken(TagsHelper.TOOL).ToString() == TagsHelper.PEN)
            {
                MovingButtonsController.Instance.ShowPenButton();
                MovingButtonsController.Instance.SetPenButtonText(button.SelectToken(TagsHelper.NAME).ToString());
            }
        }
    }
    public override void showReaction(JObject info, JObject nav)
    {
        if (info.SelectToken(TagsHelper.TEXT) != null)
        {
            var reactionText = info.SelectToken(TagsHelper.TEXT);
            ControllersHandler.Instance.GetReactionHelper().EnableReactionHelper(true);
            ControllersHandler.Instance.GetReactionHelper().ChangeReactionHelperText(reactionText.ToString());
        }
    }
}

