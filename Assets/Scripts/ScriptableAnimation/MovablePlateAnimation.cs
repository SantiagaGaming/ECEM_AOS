using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovablePlateAnimation : RepairableObject
{
    [SerializeField] private bool _mbko;
    [SerializeField] protected GameObject plate;
    [SerializeField] protected GameObject screwUp;
    [SerializeField] protected GameObject screwDown;
    [SerializeField] protected GameObject scpuTop;
    [SerializeField] protected GameObject scpuBot;
 
    public override void PlayScritableAnimtaion()
    {
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        if (canMove)
        {
            SceneSettings.Instance.CanTouch = false;
            canMove = false;
            MovingButtonsController.Instance.HideAllButtons();
            int screwZRot = 0;
            if (!_mbko)
            {
                screwUp.SetActive(true);
   
                while (screwZRot > -36)
                {
                    screwUp.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                    screwZRot--;
                    yield return new WaitForSeconds(0.01f);
                }
                    screwUp.SetActive(false);
            }

            screwDown.SetActive(true);
             screwZRot = 0;
            while (screwZRot > -36)
            {
                screwDown.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                screwZRot--;
                yield return new WaitForSeconds(0.01f);
            }
            screwDown.SetActive(false);
            int scpuXRot = 0;
            while (scpuXRot < 45)
            {
                if (!_mbko)
                    scpuTop.transform.localRotation = Quaternion.Euler(-scpuXRot,0 , 0);
                scpuBot.transform.localRotation = Quaternion.Euler(scpuXRot, 0, 0);
                scpuXRot++;
                yield return new WaitForSeconds(0.01f);
            }
            int x = 0;

            while (x <= 32)
            {
                    plate.transform.position -= new Vector3(0.012f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x++;
            }
            plate.SetActive(false);
          yield return new WaitForSeconds(0.5f);
            plate.SetActive(true);
            while (x > 0)
            {
                if (!_yPoz)
                    plate.transform.position += new Vector3(0.012f, 0, 0);
                else
                    plate.transform.position += new Vector3(0, 0.012f, 0);
                yield return new WaitForSeconds(0.02f);
                x--;
            }
            scpuXRot = 45;
            while (scpuXRot >= 0)
            {
                if (!_mbko)
                    scpuTop.transform.localRotation = Quaternion.Euler(-scpuXRot, 0, 0);
                scpuBot.transform.localRotation = Quaternion.Euler(scpuXRot, 0, 0);
                scpuXRot--;
                yield return new WaitForSeconds(0.01f);
            }
            if (!_mbko)
            {
                screwUp.SetActive(true);
                screwZRot = 0;
                while (screwZRot < 36)
                {
                    screwUp.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                    screwZRot++;
                    yield return new WaitForSeconds(0.01f);
                }
                screwUp.SetActive(false);
            }
          
            screwDown.SetActive(true);
            screwZRot = 0;
            while (screwZRot < 36)
            {
                screwDown.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                screwZRot++;
                yield return new WaitForSeconds(0.01f);
            }
            screwDown.SetActive(false);
            canMove = true;
            LampBlinkController.Instance.StartBlink();
            SceneSettings.Instance.CanTouch = true;
        }
    }

}
