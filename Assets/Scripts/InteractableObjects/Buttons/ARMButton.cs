using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARMButton : MonoBehaviour
{
    [SerializeField] private GameObject _imgToShow;
    [SerializeField] private GameObject _imgToHide;
    private Button _button;
    private void Start()
    {
      _button = GetComponent<Button>();
        _button.onClick.AddListener(ShowImage);
    }
    private void ShowImage()
    {
        _imgToShow.SetActive(true);
        _imgToHide.SetActive(false);
    }
}
