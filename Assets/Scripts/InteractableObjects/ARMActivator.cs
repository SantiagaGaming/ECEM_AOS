using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMActivator : BaseObject
{
    [SerializeField] private Canvas _arm;
    [SerializeField] private GameObject []_tempImages;
    [SerializeField] private GameObject _backButton;
    
    public override void OnClicked(InteractHand interactHand)
    {
      _arm.enabled= true;
       if(_tempImages!=null)
        {
            foreach (var item in _tempImages)
            {
                item.SetActive(false);
            }
        }
        sceneAosObject.InvokeOnClick();
        BackButtonsHandler.Instance.GetCurrentBackButton().EnableButton(false);
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
        if (_tempImages != null)
        {
            foreach (var item in _tempImages)
            {
                item.SetActive(true);
            }
        }
        _arm.enabled = false;
        _backButton.SetActive(false);
    }
}
