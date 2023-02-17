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
    [SerializeField] private LampBlinker[] _blinkers;
    private bool _blink = false;
    public int Condition { get; private set; }
    public bool Blink { get; set; } = false;
    private void Start()
    {
        if (_greenLight == null || _redLight == null)
            return;
        if (SceneSettings.Instance.Memory.UvkLights.ContainsKey(ObjectId))
        {
            EnableLight(SceneSettings.Instance.Memory.UvkLights[ObjectId]);
            Condition = SceneSettings.Instance.Memory.UvkLights[ObjectId];
        }
    }
    [AosAction(name: "������� ��������� �������")]
    public void SetCondition(int condition)
    {
        if (SceneSettings.Instance.Memory.UvkLights.ContainsKey(ObjectId))
        {
            Debug.Log(ObjectId + " condition " + condition);
            SceneSettings.Instance.Memory.UvkLights[ObjectId] = condition;
            //EnableLight(condition);
            Condition = condition;
        }
    }
    public void EnableLight(int value)
    {
        Debug.Log(_redLight.GetComponent<MeshRenderer>().enabled + "Mesh Before");
        if (_greenLight == null || _redLight == null)
            return;
        Debug.Log(_redLight.GetComponent<MeshRenderer>().enabled + "Mesh");
        if (value==0)
        {
            _greenLight.SetActive(true);
            _greenLight.GetComponent<MeshRenderer>().enabled = true;
       
            _redLight.SetActive(false);
            _redLight.GetComponent<MeshRenderer>().enabled = false;
            EnableBlinkers(true);
            _blink= false;
            Blink = true;
        }
        else if(value==1)
        {
            _greenLight.SetActive(false);
            _greenLight.GetComponent<MeshRenderer>().enabled = false;
            _redLight.SetActive(true);
            _redLight.GetComponent<MeshRenderer>().enabled = true;
            EnableBlinkers(false);
            _blink = false;
        }
        else if(value ==2)
        {
            _greenLight.SetActive(false);
            _greenLight.GetComponent<MeshRenderer>().enabled = false;
            _redLight.SetActive(false);
            _redLight.GetComponent<MeshRenderer>().enabled = false;
            EnableBlinkers(false);
            _blink = false;
        }
        else if(value==3)
        {
            _blink = true;
            EnableBlinkers(false);
            StartCoroutine(Blinker());
        }
    }
    private IEnumerator Blinker()
    {
        _greenLight.SetActive(false);
        _greenLight.GetComponent<MeshRenderer>().enabled = false;
        _redLight.SetActive(true);
        _redLight.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(Random.Range(0.1f, 1.2f));
        _greenLight.SetActive(true);
        _greenLight.GetComponent<MeshRenderer>().enabled = true;
        _redLight.SetActive(false);
        _redLight.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(Random.Range(0.1f, 1.2f));
        if(_blink)
        StartCoroutine(Blinker());
    }
    public void EnableBlinkers(bool value)
    {
        if (_blinkers == null)
            return;
        if(value)
        {
            foreach (var blinker in _blinkers)
            {
                blinker.EnableBlink(true);
            }
        }
        else
        {
            foreach (var blinker in _blinkers)
            {
                blinker.EnableBlink(false);
            }
        }   
    }
    public void EnableLamps(bool value)
    {
        _redLight.SetActive(value);
        _greenLight.SetActive(value);
    }    
}
