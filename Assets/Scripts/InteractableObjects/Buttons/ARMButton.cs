using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARMButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _imgToShow;
    [SerializeField] private GameObject[] _imgToHide;
    [SerializeField] private bool _arm;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ShowImage);
    }
    private void ShowImage()
    {
        ControllersHandler.Instance.GetAOSImageContainer().DeactivateAllImages();
        AOSARMEnabler();
        foreach (var item in _imgToShow)
        {
            if (item.GetComponent<Image>() != null)
                item.GetComponent<Image>().enabled = true;
            if (item.GetComponent<Button>() != null)
                item.GetComponent<Button>().enabled = true;
        }
        foreach (var item in _imgToHide)
        {
            if (item.GetComponent<Image>() != null)
                item.GetComponent<Image>().enabled = false;
            if (item.GetComponent<Button>() != null)
                item.GetComponent<Button>().enabled = false;
        }
    }
    private void AOSARMEnabler()
    {
        if(_arm)
        {
            SceneAosObject obj = GetComponent<SceneAosObject>();
            if (obj != null)
                obj.InvokeOnClick();
        }
    }
}
