using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARMButton : MonoBehaviour, IHoverAble
{
    [SerializeField] private GameObject _imgToShow;
    [SerializeField] private GameObject _imgToHide;
    private Button _button;

    public bool IsHoverable { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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

    public void OnHoverIn(InteractHand interactHand)
    {
        transform.localScale *= 1.5f;
    }

    public void OnHoverOut(InteractHand interactHand)
    {
        transform.localScale /= 1.5f;
    }
}
