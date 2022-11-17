using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartEndScreenView : BaseScreenView
{

    [SerializeField] private GameObject _startScreen;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;
    [SerializeField] private TextMeshProUGUI _exitSureText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;

    public void SetHeaderText(string text)
    {
        _headerText.text = text;
    }
    public void SetCommentText(string text)
    {
        _commentText.text = text;
    }
    public void SetButtonText(string text)
    {
        _nextButtonText.text = text;
    }
    public void SetExitSureText(string text)
    {
        _exitSureText.text = text;
    }
    public void SetExitText(string text)
    {
        _exitText.text = text;
    }
    public void SetWarnText(string text)
    {
        _warnText.text = text;
    }
}
