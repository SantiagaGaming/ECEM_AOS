using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveblePlate : MovebleObject
{
    public override void RepairObject()
    {
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        if (canMove)
        {
            canMove = false;
            GetComponent<Collider>().enabled = false;
            MovingButtonsController.Instance.HideAllButtons();
            int x = 0;

            while (x <= 32)
            {
                    transform.position -= new Vector3(0.012f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x++;
            }
            yield return new WaitForSeconds(0.5f);
            while (x > 0)
            {
                if (!_yPoz)
                    transform.position += new Vector3(0.012f, 0, 0);
                else
                    transform.position += new Vector3(0, 0.012f, 0);
                yield return new WaitForSeconds(0.02f);
                x--;
            }
            canMove = true;
            GetComponent<Collider>().enabled = true;
        }
    }

}
