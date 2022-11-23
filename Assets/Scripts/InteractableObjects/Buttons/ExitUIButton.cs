using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitUIButton : MonoBehaviour
{
    private Button _button;
    private void Start()
    {

        _button = GetComponent<Button>();
        _button.onClick.AddListener(ExitGame);
    }
    private void ExitGame()
    {
        API api = FindObjectOfType<API>();
        api.ExitEvent();
    }
}
