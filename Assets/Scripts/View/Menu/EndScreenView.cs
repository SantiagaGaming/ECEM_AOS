using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenView : BaseScreenView
{

    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;

    [SerializeField] private NextButton _nextButton;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private Button _backButton;


    public void SetHeaderText(string text)
    {
        _headerText.text = text;
    }
    public void SetCommentText(string text)
    {
        _commentText.text = ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text);
    }
    public void SetResultText(string text)
    {
        _resultText.text = ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text);
    }
    public void SetButtonText(string text)
    {
        _nextButtonText.text = text;
    }
    public void EnableBackButton(bool value)
    {
        _backButton.enabled = value;
    }
    public void EnableExitButton(bool value)
    {
        _exitButton.SetActive(value);
    }
    public void EnableNextButton(bool value)
    {
        _nextButton.EnableButton(value);
    }
}
