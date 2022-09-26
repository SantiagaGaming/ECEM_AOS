using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingButtonsController : MonoBehaviour
{
    public static MovingButtonsController Instance;
    [HideInInspector] public string ObjectHelperName { get; set; }
    [HideInInspector] public string ObjectName { get; set; }
    private MovebleObject _movingObject;
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

    public void SetMovingButtonsPosition(Vector3 position)
    {
        transform.position = position;
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
    public void HideAllButtons()
    {
        _watchButton.SetActive(false);
        _repairButton.SetActive(false);
        _adjustButton.SetActive(false);
        _bigWatchButton.SetActive(false);
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

}
