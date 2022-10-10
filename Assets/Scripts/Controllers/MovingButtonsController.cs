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
    private MovebleObject _movingObject;
    private PushableObject _pushableObject;
    private MovingButtonsController() { }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    [SerializeField] private GameObject _watchButton;
    [SerializeField] private GameObject _repairButton;
    [SerializeField] private GameObject _adjustButton;
    [SerializeField] private GameObject _bigWatchButton;
    [SerializeField] private GameObject _pencilButton;

    public void SetMovingButtonsPosition(Vector3 position)
    {
        transform.position = position;
        ButtonsPositionChanged?.Invoke();
    }
    public void ShowWatchButton()
    {
        _watchButton.SetActive(true);
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
    }
    public void ShowAllButtons()
    {
        _watchButton.SetActive(true);
        _repairButton.SetActive(true);
        _adjustButton.SetActive(true);
    }
    public void SetMovingObject(MovebleObject obj)
    {
        _movingObject = obj;
    }
    public void PlayRepairAnimation()
    {
        if (_movingObject != null)
            _movingObject.RepairObject();
    }
    public void SetPushableObject(PushableObject obj)
    {
        _pushableObject = obj;
    }
    public void PlayPushAnimation()
    {
        if (_pushableObject != null)
            _pushableObject.StartPush();
    }

}
