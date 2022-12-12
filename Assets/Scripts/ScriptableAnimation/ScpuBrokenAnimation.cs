using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScpuBrokenAnimation : MovablePlateAnimation
{
    [SerializeField] private GameObject[] _lampBlinkers;
    private void Start()
    {
        if (SceneSettings.Instance.Memory.ScpuBroken)
        {
            scpuTop.transform.localRotation = Quaternion.Euler(-45, 0, 0);
            scpuBot.transform.localRotation = Quaternion.Euler(45, 0, 0);
            plate.transform.position += new Vector3(-0.02f, 0,0);
            EnableLampBlinkers(false);
        }
    }
    public override void PlayScritableAnimtaion()
    {
        if (SceneSettings.Instance.Memory.ScpuBroken)
            StartCoroutine(BrokenMove());
        else StartCoroutine(Move());
    }
    private IEnumerator BrokenMove()
    {
        if (canMove)
        {
            SceneSettings.Instance.CanTouch = false;
            canMove = false;
            MovingButtonsController.Instance.HideAllButtons();
            int scpuRot = 45;
            int plateX = 0;
            while (scpuRot >= 0)
            {
                scpuTop.transform.localRotation = Quaternion.Euler(-scpuRot, 0, 0);
                scpuBot.transform.localRotation = Quaternion.Euler(scpuRot, 0, 0);
                scpuRot--;
                yield return new WaitForSeconds(0.01f);
            }
            while (plateX <= 10)
            {
                plate.transform.position += new Vector3(0.002f, 0, 0);
                yield return new WaitForSeconds(0.02f);
                plateX++;
            }
            int screwZRot = 0;
            screwUp.SetActive(true);
            while (screwZRot > -36)
            {
                screwUp.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                screwZRot--;
                yield return new WaitForSeconds(0.01f);
            }
            screwUp.SetActive(false);
            screwDown.SetActive(true);
            screwZRot = 0;
            while (screwZRot > -36)
            {
                screwDown.transform.localRotation = Quaternion.Euler(0, 180, screwZRot);
                screwZRot--;
                yield return new WaitForSeconds(0.01f);
            }
            screwDown.SetActive(false);
        }
        canMove = true;
        EnableLampBlinkers(true);
        LampBlinkController.Instance.StartBlink();
        SceneSettings.Instance.CanTouch = true;
        SceneSettings.Instance.Memory.ScpuBroken = false;
    }
    private void EnableLampBlinkers(bool value)
    {
        foreach (var light in _lampBlinkers)
        {
            light.SetActive(value);
            if (value)
                light.GetComponent<LampBlinker>().EnableBlink(value);
        }
    }
}

