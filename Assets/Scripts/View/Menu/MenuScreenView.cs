using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenView : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _infoOtkazScreen;
    [SerializeField] private GameObject _otkaziScreen;
    [SerializeField] private GameObject _exitScreen;

    [SerializeField] private TextMeshProUGUI _currentLocationText;
    [SerializeField] private TextMeshProUGUI _timertext;
    
    [SerializeField] private Button _infoOtkazButton;
    [SerializeField] private Button _showOtkazButton;
    [SerializeField] private Button _exitScreenButton;
    private void Awake()
    {
        _infoOtkazButton.onClick.AddListener(TestText);
    }
    private void TestText()
    {
        Debug.Log("Test");
    }

}
