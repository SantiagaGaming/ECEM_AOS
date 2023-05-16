using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuAPI : API
{
    [SerializeField] private MenuScreenView _menuScreen;
    [SerializeField] private TimerView _timer;

    protected override void Init()
    {
        StartCoroutine(EndTweenDelay());
    }
    private IEnumerator EndTweenDelay()
    {
        yield return new WaitForSeconds(0.2f);
        if(!SceneSettings.Instance.Memory.TimeResult)
        OnMenuInvoke();
        else
        {
            var result = SceneSettings.Instance.Memory.ResultInfo;
            var nav = SceneSettings.Instance.Memory.ResultNav;
            showResult(result, nav);
        }
    }

    public override void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {
        _menuScreen.SetCommentText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(faultInfo.SelectToken(TagsHelper.TEXT).ToString()));
        if (exitInfo.SelectToken(TagsHelper.TEXT) != null)
            _menuScreen.SetExitText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(exitInfo.SelectToken(TagsHelper.TEXT).ToString()));
        if (exitInfo.SelectToken(TagsHelper.WARN) != null)
            _menuScreen.SetWarnText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(exitInfo.SelectToken(TagsHelper.WARN).ToString()));
        Debug.Log("Exit Text " + exitInfo.SelectToken(TagsHelper.TEXT) + "WARN Text " + exitInfo.SelectToken(TagsHelper.TEXT));
    }
    public override void showTime(string time)
    {
        _timer.ShowTimerText(time);
    }
    public override void showResult(JObject info, JObject nav)
    {
        Debug.Log("IN RESULT");
        SceneSettings.Instance.Memory.Teleport = false;
        _menuScreen.SetEndHeaderText(info.SelectToken(TagsHelper.NAME).ToString());
        _menuScreen.SetEndResultText(info.SelectToken(TagsHelper.EVAL).ToString());
        _menuScreen.SetEndCommentText(info.SelectToken(TagsHelper.TEXT).ToString());
        _menuScreen.EnableEndGameScreen(true);
        _menuScreen.EnableMenuScreen(false);
        _menuScreen.EnableBackButton(false);
        _menuScreen.EnableExitButton(true);
    }
    public override void showMessage(JObject info, JObject nav)
    {
        Debug.Log("IN MESSAGEEEE");
        _menuScreen.EnableBackButton(true);
        _menuScreen.EnableExitButton(false);
        _menuScreen.EnableMenuScreen(false);
        _menuScreen.EnableEndGameScreen(true);
        _menuScreen.SetEndHeaderText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(info.SelectToken(TagsHelper.NAME).ToString()));
        _menuScreen.SetEndCommentText(info.SelectToken(TagsHelper.TEXT).ToString());
    }
}
    
