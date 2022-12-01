using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;


public class RepairableObject : MonoBehaviour, IScriptableAnimationObject
{

    [SerializeField] protected bool _yPoz;
    [SerializeField] private GameObject _child;
    protected bool canMove = true;

    public virtual void PlayScritableAnimtaion()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    { 
        if(canMove)
        {
            GetComponent<Collider>().enabled = false;
            MovingButtonsController.Instance.HideAllButtons();
          canMove = false;
        int x = 0;
        while (x<=32)
        {
            if(!_yPoz)
           transform.position += new Vector3(0.012f, 0, 0);
            else
                transform.position += new Vector3(0, 0.012f, 0);
            yield return new WaitForSeconds(0.02f);
            x++;
        }
        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().enabled = false;
                EnableChildObjects(false);
                yield return new WaitForSeconds(0.5f);
                EnableChildObjects(true);
                GetComponent<MeshRenderer>().enabled = true;
      
            }
        else 
        {
        GetComponentInChildren<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            GetComponentInChildren<MeshRenderer>().enabled = true;
        }

        while (x>0)
        {
            if (!_yPoz)
                transform.position -= new Vector3(0.012f, 0, 0);
            else
                transform.position -= new Vector3(0, 0.012f, 0);
            yield return new WaitForSeconds(0.02f);
            x--;
        }
            canMove = true;
            GetComponent<Collider>().enabled = true;

        }
    }
    private void EnableChildObjects(bool value)
    {
        if (_child != null)
            _child.SetActive(value);
    }


}
