using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UVKDoorAnimation : BaseAnimationObject, IScriptableAnimationObject
{
    public UnityAction<bool> DoorRotateEvent;

    [SerializeField] private GameObject _key;
    [SerializeField] private bool _inside;


    public override void PlayScritableAnimtaion()
    {
        NoteBookAnimation notebook = FindObjectOfType<NoteBookAnimation>();
        if(notebook!=null)
        {
            if (CanRotate && CanOpen && notebook.IsClosed)
                StartCoroutine(RotateDoor(IsClosed));
        }
    }

    private IEnumerator RotateDoor(bool value)
    {
        SceneSettings.Instance.CanTouch = false;
        DoorRotateEvent?.Invoke(true);
        GetComponent<Collider>().enabled = false;
        CanRotate = false;
        _key.SetActive(true);
        if (value)
        {
            _key.SetActive(true);
            int keyX = 0;
            while (keyX < 40)
            {
                if (_inside)
                    _key.transform.localPosition += new Vector3(0.001f, 0, 0);
                else
                    _key.transform.localPosition += new Vector3(0, 0, 0.001f);
                keyX++;
                yield return new WaitForSeconds(0.003f);
            }
            int keyXRot = -90;
            while (keyXRot > -180)
            {
                if (_inside)
                    _key.transform.localRotation = Quaternion.Euler(keyXRot, 180, 0);
                else
                    _key.transform.localRotation = Quaternion.Euler(keyXRot, 90, 0);
                keyXRot--;
                yield return new WaitForSeconds(0.003f);
            }
            if (!_inside)
            {
                int y = -90;
                while (y >= -180)
                {

                    transform.localRotation = Quaternion.Euler(0, y, 0);
                    y--;
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else
            {
                int y = 0;
                while (y >= -90)
                {

                    transform.localRotation = Quaternion.Euler(0, y, 0);
                    y--;
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
        else
        {
            MovingButtonsController.Instance.HideAllButtons();
            if (!_inside)
            {
                int y = -180;
                while (y <= -90)
                {
                    transform.localRotation = Quaternion.Euler(0, y, 0);
                    y++;
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else
            {
                int y = -90;
                while (y <= 0)
                {
                    transform.localRotation = Quaternion.Euler(0, y, 0);
                    y++;
                    yield return new WaitForSeconds(0.01f);
                }
            }

            int keyXRot = -180;
            while (keyXRot < -90)
            {
                if (_inside)
                    _key.transform.localRotation = Quaternion.Euler(keyXRot, 180, 0);
                else
                    _key.transform.localRotation = Quaternion.Euler(keyXRot, 90, 0);
                keyXRot++;
                yield return new WaitForSeconds(0.003f);
            }
            int keyX = 40;
            while (keyX > 0)
            {
                if (_inside)
                    _key.transform.localPosition -= new Vector3(0.001f, 0, 0);
                else
                    _key.transform.localPosition -= new Vector3(0, 0, 0.001f);
                keyX--;
                yield return new WaitForSeconds(0.003f);
            }
            _key.SetActive(false);
            GetComponent<Collider>().enabled = true;
        }
        IsClosed = IsClosed ? false : true;
        DoorRotateEvent?.Invoke(false);
        CanRotate = true;
        SceneSettings.Instance.CanTouch = true;
    }
}