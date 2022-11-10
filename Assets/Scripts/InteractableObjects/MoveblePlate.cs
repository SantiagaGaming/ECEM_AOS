using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveblePlate : RepairableObject
{
    [SerializeField] private bool _mbko;
    [SerializeField] private GameObject _plate;
    [SerializeField] private GameObject _screwUp;
    [SerializeField] private GameObject _screwDown;
    [SerializeField] private GameObject _scpuTop;
    [SerializeField] private GameObject _scpuBot;
 
    public override void PlayScritableAnimtaion()
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
            int screwZRot = 0;
            if (!_mbko)
            {
                _screwUp.SetActive(true);
   
                while (screwZRot > -36)
                {
                    _screwUp.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                    screwZRot--;
                    yield return new WaitForSeconds(0.01f);
                }
                    _screwUp.SetActive(false);
            }

            _screwDown.SetActive(true);
             screwZRot = 0;
            while (screwZRot > -36)
            {
                _screwDown.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                screwZRot--;
                yield return new WaitForSeconds(0.01f);
            }
            _screwDown.SetActive(false);
            int scpuXRot = 0;
            while (scpuXRot < 45)
            {
                if (!_mbko)
                    _scpuTop.transform.localRotation = Quaternion.Euler(-scpuXRot,0 , 0);
                _scpuBot.transform.localRotation = Quaternion.Euler(scpuXRot, 0, 0);
                scpuXRot++;
                yield return new WaitForSeconds(0.01f);
            }
            int x = 0;

            while (x <= 32)
            {
                    _plate.transform.position -= new Vector3(0.012f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                x++;
            }
            _plate.SetActive(false);
          yield return new WaitForSeconds(0.5f);
            _plate.SetActive(true);
            while (x > 0)
            {
                if (!_yPoz)
                    _plate.transform.position += new Vector3(0.012f, 0, 0);
                else
                    _plate.transform.position += new Vector3(0, 0.012f, 0);
                yield return new WaitForSeconds(0.02f);
                x--;
            }
            scpuXRot = 45;
            while (scpuXRot >= 0)
            {
                if (!_mbko)
                    _scpuTop.transform.localRotation = Quaternion.Euler(-scpuXRot, 0, 0);
                _scpuBot.transform.localRotation = Quaternion.Euler(scpuXRot, 0, 0);
                scpuXRot--;
                yield return new WaitForSeconds(0.01f);
            }
            if (!_mbko)
            {
                _screwUp.SetActive(true);
                screwZRot = 0;
                while (screwZRot < 36)
                {
                    _screwUp.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                    screwZRot++;
                    yield return new WaitForSeconds(0.01f);
                }
                _screwUp.SetActive(false);
            }
          
            _screwDown.SetActive(true);
            screwZRot = 0;
            while (screwZRot < 36)
            {
                _screwDown.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                screwZRot++;
                yield return new WaitForSeconds(0.01f);
            }
            _screwDown.SetActive(false);
            canMove = true;
            GetComponent<Collider>().enabled = true;
            LampBlinkController.Instance.StartBlink();
        }
    }

}
