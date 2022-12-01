using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookAnimation : MonoBehaviour, IScriptableAnimationObject
{
    [SerializeField] private GameObject _noteBook;
    [SerializeField] private GameObject _lid;
    [HideInInspector]public bool IsClosed { get; private set; } = true;

    private bool _canRotate = true;
    public void PlayScritableAnimtaion()
    {
        if (_canRotate)
           StartCoroutine(ShowNoteBook(IsClosed));
    }

    private IEnumerator ShowNoteBook(bool value)
    {
        SceneSettings.Instance.CanTouch = false;
        _canRotate = false;
        if (value)
        {
            ControllersHandler.Instance.GetBackButtonsHandler().GetCurrentBackButton().EnableObject(false);
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
            ControllersHandler.Instance.GetBackButtonsHandler().GetCurrentBackButton().EnableObject(true);
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
        IsClosed = IsClosed ? false : true;
        _canRotate = true;
        SceneSettings.Instance.CanTouch = true;
    }
}
