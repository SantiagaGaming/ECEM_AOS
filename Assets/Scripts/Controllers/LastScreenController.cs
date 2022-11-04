using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LastScreenController : MonoBehaviour
{
    [SerializeField] private GameObject[] _screens;
    [SerializeField] private MainMenuController _mainMenuController;
    [SerializeField] private GameObject _lastScreen;
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _backButton;

    public void SetHeaderText(string text)
    {
        _headerText.text = text;
    }
    public void SetCommentText(string text)
    {
        _commentText.text = text;
    }

    public void ShowMessageScreen()
    {

        foreach (var item in _screens)
        {
            item.SetActive(false);
        }
        _lastScreen.SetActive(true);
    }

    public void ShowLastScreen()
    {
        _mainMenuController.AllowTeleport(false);
        foreach (var item in _screens)
        {
            item.SetActive(false);
        }
        _backButton.SetActive(false);
        _lastScreen.SetActive(true);
        _exitButton.SetActive(true);
    }
}
