using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreenView : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _infoOtkazScreen;
    [SerializeField] private GameObject _OtkaziScreen;
    [SerializeField] private GameObject _exitScreen;

    [SerializeField] private TextMeshProUGUI _currentLocationText;
    [SerializeField] private TextMeshProUGUI _timertext;
}
