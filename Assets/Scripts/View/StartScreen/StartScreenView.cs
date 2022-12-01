using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreenView : MonoBehaviour
{
    [SerializeField] private Canvas _startScreenCanvas;        
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;

    public void EnableStartScreen(bool value)
    {
        _startScreenCanvas.enabled = value;   
    }
    public void SetHeaderText(string text)
    {
        _headerText.text = text;
    }
    public void SetCommentText(string text)
    {
        _commentText.text = ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text);    
    }

    public void SetButtonText(string text)
    {
        _nextButtonText.text = text;
    }

}
