using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuAPI : API
{
    [SerializeField] private EndScreenView _endScreenView;
    [SerializeField] private MenuScreenView _menuScreen;
    [SerializeField] private ScreenChanger _menuScreenChanger;
    [SerializeField] private TimerView _timer;
    [SerializeField] private NextButton _nextButton;

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
        _menuScreen.SetOtkazText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(faultInfo.SelectToken(TagsHelper.TEXT).ToString()));
        if (exitInfo.SelectToken(TagsHelper.TEXT) != null)
            _menuScreen.SetExitText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(exitInfo.SelectToken(TagsHelper.TEXT).ToString()));
        if (exitInfo.SelectToken(TagsHelper.WARN) != null)
            _menuScreen.SetWarnText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(exitInfo.SelectToken(TagsHelper.WARN).ToString()));
    }
    public override void showTime(string time)
    {
        _timer.ShowTimerText(time);
    }
    public override void showResult(JObject info, JObject nav)
    {
        SceneSettings.Instance.Memory.Teleport = false;
        _menuScreenChanger.EnableScreen(TagsHelper.INFO);
        _endScreenView.SetHeaderText(info.SelectToken(TagsHelper.NAME).ToString());
        _endScreenView.SetResultText(info.SelectToken(TagsHelper.EVAL).ToString());
        _endScreenView.SetCommentText(info.SelectToken(TagsHelper.TEXT).ToString());
        _nextButton.ChangeActionOnButton(nav.SelectToken(TagsHelper.OK).SelectToken(TagsHelper.ACTION).ToString());
        _endScreenView.EnableNextButton(false);
        _endScreenView.EnableExitButton(true);
  
    }
    public override void showMessage(JObject info, JObject nav)
    {
        _menuScreenChanger.EnableScreen(TagsHelper.INFO);
        _endScreenView.EnableNextButton(false);
        _endScreenView.EnableBackButton(true);
        _endScreenView.SetHeaderText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(info.SelectToken(TagsHelper.NAME).ToString()));
        _endScreenView.SetCommentText(info.SelectToken(TagsHelper.TEXT).ToString());
    }
}
    
