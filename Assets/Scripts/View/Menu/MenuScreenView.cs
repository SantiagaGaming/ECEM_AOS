using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;
    [SerializeField] private TextMeshProUGUI _endHeaderText;
    [SerializeField] private TextMeshProUGUI _endCommentText;
    [SerializeField] private TextMeshProUGUI _endResultText;

    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _backButton;

    public void EnableEndGameScreen(bool value)
    {
        _endGameScreen.SetActive(value);
    }
    public void EnableMenuScreen(bool value)
    {
        _menuScreen.SetActive(value);
    }
    public void SetEndHeaderText(string text)
    {
        _endHeaderText.text = text;
    }
    public void SetCommentText(string text)
    {
        _commentText.text = ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text);
    }
    public void SetEndResultText(string text)
    {
        _endResultText.text = ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text);
    }

    public void EnableExitButton(bool value)
    {
        _exitButton.SetActive(value);
    }
    public void SetEndCommentText(string text)
    {
        _endCommentText.text= text;
    }
    public void SetExitText(string text)
    {
        _exitText.text = text;
    }
    public void SetWarnText(string text)
    {
        _warnText.text = text;
    }
    public void EnableBackButton(bool value)
    {
        _backButton.SetActive(value);
    }
}
