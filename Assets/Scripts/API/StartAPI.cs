using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAPI : API
{
    [SerializeField] private StartScreenView _startScreenView;
    [SerializeField] private NextButton _nextButton;
    protected override void Init()
    {
        if (_nextButton != null)
            _nextButton.NextButtonClickedEvent += OnNavActionInvoke;
        SceneSettings.Instance.SetMemory();
    }
    public override void showWelcome(JObject info, JObject nav)
    {
        _startScreenView.EnableStartScreen(true);
        _startScreenView.SetHeaderText(info.SelectToken(TagsHelper.NAME).ToString());
        _startScreenView.SetCommentText(info.SelectToken(TagsHelper.TEXT).ToString());
        _startScreenView.SetButtonText(nav.SelectToken(TagsHelper.OK).SelectToken(TagsHelper.CAPTION).ToString());
        _nextButton.ChangeActionOnButton(nav.SelectToken(TagsHelper.OK).SelectToken(TagsHelper.ACTION).ToString());
    }
    public override void showFaultInfo(JObject info, JObject nav)
    {
        SceneSettings.Instance.Memory.Teleport = true;
        _startScreenView.SetHeaderText(info.SelectToken(TagsHelper.NAME).ToString());
        _startScreenView.SetCommentText(info.SelectToken(TagsHelper.TEXT).ToString());
        _startScreenView.SetButtonText(nav.SelectToken(TagsHelper.OK).SelectToken(TagsHelper.CAPTION).ToString());
        _nextButton.ChangeActionOnButton(nav.SelectToken(TagsHelper.OK).SelectToken(TagsHelper.ACTION).ToString());
    }
}

