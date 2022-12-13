using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour, IScriptableAnimationObject
{
    [SerializeField] private GameObject _plomb;
    [SerializeField] private bool _fixed;
    private bool _pushed = true;
    private bool _canPush = true;

    public void PlayScritableAnimtaion()
    {
        if (_canPush)
            StartCoroutine(Push(_pushed));
    }
    private IEnumerator Push(bool value)
    {
        if(_plomb!=null)
            _plomb.SetActive(false);
        _canPush = false;
        GetComponent<Collider>().enabled = false;
        int x = 0;
        if(_fixed)
        {
            while (x < 8)
            {
                if (!value)
                    transform.position += new Vector3(-0.001f, 0, 0);
                else if (value)
                    transform.position += new Vector3(0.001f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x++;
            }
        }
        else
        {
            while (x < 8)
            {
                transform.position += new Vector3(0.001f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x++;
            }
            while (x>=0)
            {
                transform.position += new Vector3(-0.001f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x--;
            }
        }
        _pushed = !value;
        GetComponent<Collider>().enabled = true;
        _canPush = true;
    }
    }



