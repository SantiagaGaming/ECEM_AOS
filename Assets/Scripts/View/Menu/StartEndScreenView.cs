using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartEndScreenView : MonoBehaviour
{
    [SerializeField] private NextButton _nextButton;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;

    private void OnEnable()
    {
        _nextButton.NextButtonClickedEvent += OnNextButtonClicked;

    }
    private void OnDisable()
    {
        _nextButton.NextButtonClickedEvent -= OnNextButtonClicked;
    }
    private void OnNextButtonClicked(string value)
    {
        if (value == "next")
            _nextButtonText.text = "Начать";
    }
    public void EnableStartScteen(bool value)
    {
        _startScreen.SetActive(value);
    }
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
}
