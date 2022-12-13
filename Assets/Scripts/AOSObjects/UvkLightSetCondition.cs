using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "UvkLight")]

public class UvkLightSetCondition : AosObjectBase
{
    [SerializeField] private GameObject _greenLight;
    [SerializeField] private GameObject _redLight;
    private bool _blink = false;
    private void Start()
    {
        if (_greenLight == null || _redLight == null)
            return;
        if (SceneSettings.Instance.Memory.UvkLights.ContainsKey(ObjectId))
        {
            EnableLight(SceneSettings.Instance.Memory.UvkLights[ObjectId]);
            Debug.Log("LIGHT" + SceneSettings.Instance.Memory.UvkLights[ObjectId]);
        }
    }
    [AosAction(name: "������� ��������� �������")]
    public void SetCondition(int condition)
    {
        if (SceneSettings.Instance.Memory.UvkLights.ContainsKey(ObjectId))
        {
            SceneSettings.Instance.Memory.UvkLights[ObjectId] = condition;
            EnableLight(condition);
        }
    }
    private void EnableLight(int value)
    {
        if (_greenLight == null || _redLight == null)
            return;
        if (value==0)
        {
            _greenLight.SetActive(true);
            _redLight.SetActive(false);
            _blink= false;
        }
        else if(value==1)
        {
            _greenLight.SetActive(false);
            _redLight.SetActive(true);
            _blink = false;
        }
        else if(value ==2)
        {
            _greenLight.SetActive(false);
            _redLight.SetActive(false);
            _blink = false;
        }
        else if(value==3)
        {
            _blink = true;
            StartCoroutine(Blinker());
        }
    }
    private IEnumerator Blinker()
    {
        _greenLight.SetActive(false);
        _redLight.SetActive(true);
        yield return new WaitForSeconds(Random.Range(0.1f, 1.2f));
        _greenLight.SetActive(true);
        _redLight.SetActive(false);
        yield return new WaitForSeconds(Random.Range(0.1f, 1.2f));
        if(_blink)
        StartCoroutine(Blinker());
    }
}
