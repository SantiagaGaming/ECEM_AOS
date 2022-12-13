using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushableObjectWithMemory : PushableObject
{
    public UnityAction<bool> OnPushed;
    private bool _pushed = false;
    public override void PlayScritableAnimtaion()
    {
        if (canPush)
            StartCoroutine(Push(_pushed));
    }
    private IEnumerator Push(bool value)
    {
        OnPushed?.Invoke(!value);
        if (plomb != null)
            plomb.SetActive(false);
        canPush = false;
        GetComponent<Collider>().enabled = false;
        int x = 0;
        while (x < 8)
        {
            if (!value)
                transform.position += new Vector3(0.001f, 0, 0);
            else if (value)
                transform.position += new Vector3(-0.001f, 0, 0);
            yield return new WaitForSeconds(0.02f);
            x++;
        }
        _pushed = !value;
        GetComponent<Collider>().enabled = true;
        canPush = true;
    }
    public void PushInStrart()
    {
        _pushed = true;
        transform.position+= new Vector3(+0.008f, 0, 0);
        plomb.SetActive(false);
    }
    }
