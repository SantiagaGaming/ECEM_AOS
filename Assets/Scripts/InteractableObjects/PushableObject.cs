using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour, IScriptableAnimationObject
{
    [SerializeField] private GameObject _plomb;
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
            while (x < 8)
            {
            if(!value)
                transform.position += new Vector3(-0.001f, 0, 0);
        else
                transform.position += new Vector3(0.001f, 0, 0);
            yield return new WaitForSeconds(0.02f);
                x++;
            }
        _pushed = !value;
        GetComponent<Collider>().enabled = true;
        _canPush = true;

    }

    }



