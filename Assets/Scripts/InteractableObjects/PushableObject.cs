using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour, IScriptableAnimationObject
{
    [SerializeField] protected GameObject plomb;
    protected bool canPush = true;

    public virtual void PlayScritableAnimtaion()
    {
        if (canPush)
            StartCoroutine(Push());
    }
    private IEnumerator Push()
    {
        if(plomb!=null)
            plomb.SetActive(false);
        canPush = false;
        GetComponent<Collider>().enabled = false;
        int x = 0;
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
        GetComponent<Collider>().enabled = true;
        canPush = true;
    }
    }



