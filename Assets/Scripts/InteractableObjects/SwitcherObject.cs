using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherObject : RepairableObject
{
    [SerializeField] private GameObject _switcher;
    private bool _canRotate = true;
    private bool _side = true;
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
}

