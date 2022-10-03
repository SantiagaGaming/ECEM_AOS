using AosSdk.Core.Player.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbtcDoor : BaseObject
{
    private bool _side = true;
    private bool _canRotate = true;

    [HideInInspector] public bool CanOpen = true;
    [SerializeField] private GameObject[] _colliderObjects;
    public override void OnClicked(InteractHand interactHand)
    {
        if (_canRotate && CanOpen)
        {
            StartCoroutine(RotateDoor(_side));
            if (_side)
                _side = false;
            else _side = true;
        }
    }
    private IEnumerator RotateDoor(bool value)
    {

        GetComponent<Collider>().enabled = false;
        _canRotate = false;

        if (value)
        {
            ColliderEnabler(false);

            int y = -107;
            while (y <= -17)
            {
                transform.localRotation = Quaternion.Euler(-90, y, 17.137f);
                y++;
                yield return new WaitForSeconds(0.01f);
            }
            ColliderEnabler(true);
        }

        else
        {
            MovingButtonsController.Instance.HideAllButtons();
            ColliderEnabler(false);
            int y = -17;
            while (y >= -107)
            {
                transform.localRotation = Quaternion.Euler(-90, y, 17.137f);
                y--g;
                yield return new WaitForSeconds(0.01f);
            }



        }
        _canRotate = true;
        GetComponent<Collider>().enabled = true;
    }
    public void ColliderEnabler(bool value)
    {
        if(_colliderObjects!=null)
        {
            foreach (var item in _colliderObjects)
            {
                item.GetComponent<Collider>().enabled = value;
            }

        }
    
    }


}