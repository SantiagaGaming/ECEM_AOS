using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class MenuScreenButton : MonoBehaviour
{
    public UnityAction<string> MenuScreenButtonClickedEvent;

    [SerializeField] private string _openScreenName;

    private Button _button;
    private void Start()
    {
      _button = GetComponent<Button>();
      _button.onClick.AddListener(EnableScreenByName);
    }
    private void EnableScreenByName()
    {
        MenuScreenController.Instance.EnableMenuScreen(_openScreenName);
    }
}
