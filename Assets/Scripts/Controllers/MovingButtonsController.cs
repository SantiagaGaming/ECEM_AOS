using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingButtonsController : MonoBehaviour
{
    public static MovingButtonsController Instance;
    public UnityAction ButtonsPositionChanged;
    [HideInInspector] public string ObjectHelperName { get; set; }
    [HideInInspector] public string ObjectName { get; set; }

    public BaseObject CurrentBaseObject { get; set;}
    private MovingButtonsController() { }

    private IScriptableAnimationObject _tempRepairableObject;
    private IScriptableAnimationObject _tempPushableObject;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [SerializeField] private GameObject _watchButton;
    [SerializeField] private GameObject _repairButton;
    [SerializeField] private GameObject _repairButton_1;
    [SerializeField] private GameObject _handButton;
    [SerializeField] private GameObject _handButton_1;
    [SerializeField] private GameObject _handButton_2;
    [SerializeField] private GameObject _penButton;

    public void SetMovingButtonsPosition(Vector3 position, BaseObject obj)
    {
        HideAllButtons();
        transform.position = position;
        CurrentBaseObject = obj;
    }
    public void ShowWatchButton()
    {
        _watchButton.SetActive(true);
    }
    public void ShowRepairButton()
    {
        _repairButton.SetActive(true);
    }
    public void ShowRepair1Button()
    {
        _repairButton_1.SetActive(true);
    }
    public void ShowHandButton()
    {
        _handButton.SetActive(true);
        Debug.Log("HAAAAND");
    }
    public void ShowHand1Button()
    {
        _handButton_1.SetActive(true);
    }
    public void ShowHand2Button()
    {
        _handButton_2.SetActive(true);
    }
    public void ShowPenButton()
    {
        _penButton.SetActive(true);
    }
    public void HideAllButtons()
    {
        _watchButton.SetActive(false);
        _repairButton.SetActive(false);
        _handButton.SetActive(false);
        _handButton_1.SetActive(false);
        _handButton_2.SetActive(false);
        _penButton.SetActive(false);
        _repairButton_1.SetActive(false);
        ButtonsPositionChanged?.Invoke();
    }
    public void SetWatchButtonText(string text)
    {
        _watchButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text));
    }
    public void SetRepairButtonText(string text)
    {
        _repairButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text));
    }
    public void SetRepair1ButtonText(string text)
    {
        _repairButton_1.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text));
    }
    public void SetHandButtonText(string text)
    {
        _handButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text));
    }
    public void SetHand1ButtonText(string text)
    {
        _handButton_1.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text));
    }
    public void SetHand2ButtonText(string text)
    {
        _handButton_2.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text));
    }
    public void SetPenButtonText(string text)
    {
        _penButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text));
    }
    public void SetToolObject(RepairableObject obj)
    {
        _tempRepairableObject = obj;
    }
    public void PlayToolAnimation()
    {
        if(_tempRepairableObject!=null)
        _tempRepairableObject.PlayScritableAnimtaion();
    }
    public void SetPushObject(PushableObject obj)
    {
        _tempPushableObject = obj;
    }
    public void PlayPushAnimation()
    {
        if (_tempPushableObject != null)
            _tempPushableObject.PlayScritableAnimtaion();
    }

}
