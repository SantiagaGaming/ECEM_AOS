using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UvkUpLampLights : MonoBehaviour
{
    [SerializeField] private LampMaterialChanger _lampMaterialChanger;
    private void Start()
    {
        SetLampCondition();
    }
    public void SetLampCondition()
    {
        if (SceneSettings.Instance.Memory.LampLights == 0)
        {
            StopCoroutine("BlinkLights");
            _lampMaterialChanger.SetNormalMaterial();
        }
        else if (SceneSettings.Instance.Memory.LampLights == 1)
        {
            StopCoroutine("BlinkLights");
            _lampMaterialChanger.SetBrokenMaterial();
        }
        else if (SceneSettings.Instance.Memory.LampLights == 2)
            StartCoroutine("BlinkLights");
    }
    private IEnumerator BlinkLights()
    {
        _lampMaterialChanger.SetBrokenMaterial();
        yield return new WaitForSeconds(0.5f);
        _lampMaterialChanger.SetNormalMaterial();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(BlinkLights());
    }
}
