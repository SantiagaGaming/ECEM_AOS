using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuTextView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _exitSureText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;
    public void SetHeaderText(string text)
    {
        _infoHeaderText.text = text;    
    }
    public void SetInfoText(string text)
    {
        _infoText.text = text;
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
