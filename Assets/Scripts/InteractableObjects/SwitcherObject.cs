using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherObject : RepairableObject
{
    [SerializeField] private GameObject _switcher;
    [SerializeField] private MovingButtonWithAction _buttonOn;
    [SerializeField] private MovingButtonWithAction _buttonOff;
    [SerializeField] private GameObject _lamp;
    private bool _canRotate = true;
    private bool _side = true;
    private void Start()
    {
        if (SceneSettings.Instance.Memory.QfCondition)
        {
            _side = true;
            _switcher.transform.localRotation = Quaternion.Euler(56, 0, 0);
            _lamp.SetActive(true);
        }
    }
    private void OnEnable()
    {
        _buttonOn.ButtonNumberEvent += OnMoveButton;
        _buttonOff.ButtonNumberEvent += OnMoveButton;
    }
    private void OnDisable()
    {
        _buttonOn.ButtonNumberEvent -= OnMoveButton;
        _buttonOff.ButtonNumberEvent -= OnMoveButton;
    }
    public override void PlayScritableAnimtaion()
    {
     
        if (_canRotate)
        {
            StartCoroutine(Rotate(_side));
            if (_side)
                _side = false;
            else _side = true;
        }
    }

    private IEnumerator Rotate(bool value)
    {
        GetComponent<Collider>().enabled = false;
        _canRotate = false;
        MovingButtonsController.Instance.HideAllButtons();

        if (value)
        {
             int x = 56;
            while (x >= -34)
            {
                _switcher.transform.localRotation = Quaternion.Euler(x,0, 0);
                x--;
                yield return new WaitForSeconds(0.01f);
            }
            _lamp.SetActive(false);
        }
        else
        {
            int x = -34;
            while (x <= 56)
            {
                _switcher.transform.localRotation = Quaternion.Euler(x,0, 0);
                x++;
                yield return new WaitForSeconds(0.01f);
            }
            _lamp.SetActive(true);
        }

        _canRotate = true;
        GetComponent<Collider>().enabled = true;
    }
    public void OnMoveButton(int value)
    {
        if (CurrentAOSObject.Instance.SceneAosObject.ObjectId != "feed_tsch_qf")
            return;
if(value==0)
            StartCoroutine(Rotate(_side));
else if(value==1)
            StartCoroutine(Rotate(!_side));
        SceneSettings.Instance.Memory.QfCondition = false;

    }
}

