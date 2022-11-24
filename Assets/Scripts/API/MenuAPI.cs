using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAPI : API
{
    [SerializeField] private StartEndScreenView _startEndScreenView;
    [SerializeField] private ScreenChanger _menuScreenChanger;
    [SerializeField] private StartEndScreenView _startEndScreen;
    [SerializeField] private TimerView _timer;
    [SerializeField] private NextButton _nextButton;
    protected override void Init()
    {
        WebSocketWrapper.Instance.OnClientConnected += OnInvokeEndTween;
        if (_nextButton != null)
            _nextButton.NextButtonClickedEvent += OnNextButtonClicked;
        LocationName = "Menu";
        OnInvokeEndTween();
    }

    public override void showWelcome(JObject info, JObject nav)
    {
        _menuScreenChanger.EnableScreen("Info");
        _startEndScreenView.SetHeaderText(info.SelectToken("name").ToString());
        _startEndScreenView.SetCommentText(info.SelectToken("text").ToString());
        _startEndScreenView.SetButtonText(nav.SelectToken("ok").SelectToken("caption").ToString());
        _nextButton.ChangeActionOnButton(nav.SelectToken("ok").SelectToken("action").ToString());
        PlayerPrefs.SetString("MenuScene", "Start");
    }
    public override void showFaultInfo(JObject info, JObject nav)
    {
        _startEndScreenView.SetHeaderText(info.SelectToken("name").ToString());
        _startEndScreenView.SetCommentText(info.SelectToken("text").ToString());
        _startEndScreenView.SetButtonText(nav.SelectToken("ok").SelectToken("caption").ToString());
        _nextButton.ChangeActionOnButton(nav.SelectToken("ok").SelectToken("action").ToString());
    }
    public override void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {
        _menuScreenChanger.EnableScreen("Menu");
        _startEndScreenView.SetHeaderText(faultInfo.SelectToken("name").ToString());
        _startEndScreenView.SetCommentText(faultInfo.SelectToken("text").ToString());
        _startEndScreenView.SetExitSureText(exitInfo.SelectToken("quest").ToString());
        if (exitInfo.SelectToken("text") != null)
            _startEndScreenView.SetExitText(HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString()));
        if (exitInfo.SelectToken("warn") != null)
            _startEndScreenView.SetWarnText(HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString()));
    }
    public override void showTime(string time)
    {
        _timer.ShowTimerText(time);
    }
    public override void showResult(JObject info, JObject nav)
    {
        PlayerPrefs.SetString("Teleport", "false");
        _menuScreenChanger.EnableScreen("Info");
        _startEndScreenView.SetHeaderText(info.SelectToken("name").ToString());
        _startEndScreenView.SetCommentText(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString()));
        _nextButton.ChangeActionOnButton(nav.SelectToken("ok").SelectToken("action").ToString());
    }
    public override void showMessage(JObject info, JObject nav)
    {
        _menuScreenChanger.EnableScreen("Info");
        _startEndScreen.EnableNextButton(false);
        _startEndScreen.EnableBackButton(true);
        _startEndScreenView.SetHeaderText(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("name").ToString()));
        _startEndScreenView.SetCommentText(info.SelectToken("text").ToString());
    }


}
    
