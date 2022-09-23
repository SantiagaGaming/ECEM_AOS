using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.Player;
using AosSdk.Core.Player.Pointer;
using UnityEngine;
using UnityEngine.Events;

public class ÑupboardDoor : BaseObject
{
    private bool _side = true;
    private bool _canRotate = true;
    [SerializeField] private GameObject _key;
    [HideInInspector] public bool CanOpen = true;
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
        _key.SetActive(true);
        if (value)
        {
            _key.SetActive(true);
            int keyX = 0;
            while (keyX < 40)
            {
                _key.transform.localPosition += new Vector3(0.001f, 0,0);
                keyX++;
                yield return new WaitForSeconds(0.005f);
            }
            int keyXRot = -90;
            while (keyXRot > -180)
            {
                _key.transform.localRotation = Quaternion.Euler(keyXRot, 180, 0);
                keyXRot--;
                yield return new WaitForSeconds(0.01f);
            }
            int y = 90;
            while (y >= 0)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
        }

        else
        {
            int y = 0;
            while (y <= 90)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y++;
                yield return new WaitForSeconds(0.01f);
            }
            int keyXRot = -180;
            while (keyXRot < -90)
            {
                _key.transform.localRotation = Quaternion.Euler(keyXRot, 180, 0);
                keyXRot++;
                yield return new WaitForSeconds(0.01f);
            }
            int keyX = 40;
            while (keyX > 0)
            {
                _key.transform.localPosition -= new Vector3(0.001f, 0, 0);
                keyX--;
                yield return new WaitForSeconds(0.01f);
            }
            _key.SetActive(false);

        }
        _canRotate = true;
        GetComponent<Collider>().enabled = true;
    }
}
