using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;


public class MovebleObject : MonoBehaviour
{

    [SerializeField][HideInInspector] protected bool _condition;
    [SerializeField] protected bool _yPoz;
    protected bool canMove = true;

    public virtual void RepairObject()
    {
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    { if(canMove)
        {
            GetComponent<Collider>().enabled = false;
            MovingButtonsController.Instance.HideAllButtons();
          canMove = false;
        int x = 0;
        _condition = true;
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
            yield return new WaitForSeconds(0.5f);
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
    public bool GetCondition()
    {
        return _condition;
    }
    public void SetCondition(bool value)
    {
        _condition = value;
    }
}
