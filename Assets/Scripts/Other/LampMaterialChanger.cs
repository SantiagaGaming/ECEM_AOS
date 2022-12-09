using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampMaterialChanger : MonoBehaviour
{
    [SerializeField] private Material _normalMat;
    [SerializeField] private Material _brokenMat;

    public void SetNormalMaterial()
    {
        GetComponent<MeshRenderer>().material= _normalMat;
    }
    public void SetBrokenMaterial()
    {
        GetComponent<MeshRenderer>().material = _brokenMat;
    }
}
