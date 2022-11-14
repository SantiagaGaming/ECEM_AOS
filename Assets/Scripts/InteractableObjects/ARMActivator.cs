using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMActivator : BaseObject
{
    [SerializeField] private Canvas _arm;
    [SerializeField] private GameObject _tempImage;
    [SerializeField] private GameObject _backButton;
    
    public override void OnClicked(InteractHand interactHand)
    {
      _arm.enabled= true;
        _tempImage.SetActive(false);
        GetComponent<Collider>().enabled = false;
        _backButton.SetActive(true);
    }
    private void OnEnable()
    {
        if (_backButton != null)
            _backButton.GetComponent<BackButtonObject>().BackButtonClickEvent += OnBackClick;
    }
    private void OnDisable()
    {
        if (_backButton != null)
            _backButton.GetComponent<BackButtonObject>().BackButtonClickEvent -= OnBackClick;
    }

    private void OnBackClick()
    {
        _tempImage.SetActive(true);
        _arm.enabled = false;
        GetComponent<Collider>().enabled = true;
        _backButton.SetActive(false);
    }
}
