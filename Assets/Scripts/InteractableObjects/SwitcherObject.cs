using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherObject : RepairableObject
{
    [SerializeField] private GameObject _switcher;
    [SerializeField] private HandButton _buttonOn;
    [SerializeField] private HandButton _buttonOff;
    private bool _canRotate = true;
    private bool _side = true;
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
            while (x >= -20)
            {
                _switcher.transform.localRotation = Quaternion.Euler(x,0, 0);
                x--;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {
            int x = -20;
            while (x <= 56)
            {
                _switcher.transform.localRotation = Quaternion.Euler(x,0, 0);
                x++;
                yield return new WaitForSeconds(0.01f);
            }
        }

        _canRotate = true;
        GetComponent<Collider>().enabled = true;
    }
    public void OnMoveButton(int value)
    {
if(value==0)
            StartCoroutine(Rotate(_side));
else if(value==1)
            StartCoroutine(Rotate(!_side));

    }
}

