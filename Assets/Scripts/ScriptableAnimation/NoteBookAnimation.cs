using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookAnimation : MonoBehaviour, IScriptableAnimationObject
{
    [SerializeField] private GameObject _noteBook;
    [SerializeField] private GameObject _lid;
    private bool _isClosed = true;
    private bool _canRotate = true;

    public void PlayScritableAnimtaion()
    {
        if (_canRotate)
           StartCoroutine(ShowNoteBook(_isClosed));
    }

    private IEnumerator ShowNoteBook(bool value)
    {
        _canRotate = false;
        if (value)
        {
            int z = 0;
            while (z <= 35)
            {
                _noteBook.transform.localPosition -= new Vector3(0.01f, 0, 0);
                z++;
                yield return new WaitForSeconds(0.01f);
            }
            int x = 95;
            while (x >= 0)
            {
                _lid.transform.localRotation = Quaternion.Euler(x, 0, 0);
                x--;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else
        {

            int x = 0;
            while (x <= 95)
            {
                _lid.transform.localRotation = Quaternion.Euler(x, 0, 0);
                x++;
                yield return new WaitForSeconds(0.01f);
            }
            int z = 35;
            while (z >= 0)
            {
                _noteBook.transform.localPosition += new Vector3(0.01f, 0, 0);
                z--;
                yield return new WaitForSeconds(0.01f);
            }

        }
        _isClosed = _isClosed ? false : true;
        _canRotate = true;
    }
}
