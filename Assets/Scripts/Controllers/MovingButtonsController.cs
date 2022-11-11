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
    private RepairableObject _tempRepairableObject;
    private PushableObject _tempPushableObject;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [SerializeField] private GameObject _watchButton;
    [SerializeField] private GameObject _repairButton;
    [SerializeField] private GameObject _adjustButton;
    [SerializeField] private GameObject _bigWatchButton;
    [SerializeField] private GameObject _pencilButton;

    public void SetMovingButtonsPosition(Vector3 position, BaseObject obj)
    {
        transform.position = position;
        CurrentBaseObject = obj;
    }
    public void ShowWatchButton()
    {
        _watchButton.SetActive(true);
    }
    public void HideWatchButton()
    {
        _watchButton.SetActive(false);
    }
    public void ShowRepairButton()
    {
        _repairButton.SetActive(true);
    }
    public void HideRepairButton()
    {
        _repairButton.SetActive(false);
    }
    public void ShowAdjustButton()
    {
        _adjustButton.SetActive(true);
    }
    public void HideAdjustButton()
    {
        _adjustButton.SetActive(false);
    }
    public void ShowBigWatchButton()
    {
        _bigWatchButton.SetActive(true);
    }
    public void ShowPencilButton()
    {
        _pencilButton.SetActive(true);
    }
    public void HideAllButtons()
    {
        _watchButton.SetActive(false);
        _repairButton.SetActive(false);
        _adjustButton.SetActive(false);
        _bigWatchButton.SetActive(false);
        _pencilButton.SetActive(false);
        ButtonsPositionChanged?.Invoke();
    }
    public void ShowAllButtons()
    {
        _watchButton.SetActive(true);
        _repairButton.SetActive(true);
        _adjustButton.SetActive(true);
    }
    public void SetWatchButtonText(string text)
    {
        _watchButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(text);
    }

    public void SetRepairButtonText(string text)
    {
        _repairButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(text);
    }
    public void SetAdjustButtonText(string text)
    {
        _adjustButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(text);
    }
    public void SetRepairableObject(RepairableObject obj)
    {
        _tempRepairableObject = obj;
    }
    public void PlayRepairAnimation()
    {
        if(_tempRepairableObject!=null)
        _tempRepairableObject.PlayScritableAnimtaion();
    }
    public void SetPushableObject(PushableObject obj)
    {
        _tempPushableObject = obj;
    }
    public void PushPushableObject()
    {
        if (_tempPushableObject != null)
            _tempPushableObject.StartPush();
    }

}
