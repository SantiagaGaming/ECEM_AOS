using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UvkUpLampLights : MonoBehaviour
{
    [SerializeField] private LampMaterialChanger _lampMaterialChanger;
    private bool _blink = true;
    private void Start()
    {
        SetLampCondition();
    }
    public void SetLampCondition()
    {
        if (SceneSettings.Instance.Memory.LampLights == 0)
        {
            _blink= false;
            _lampMaterialChanger.SetNormalMaterial();
        }
        else if (SceneSettings.Instance.Memory.LampLights == 1)
        {
            _blink = false;
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
        if(_blink)
        StartCoroutine(BlinkLights());
    }
}
