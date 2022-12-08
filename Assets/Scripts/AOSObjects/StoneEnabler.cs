using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "����� ������")]
public class StoneEnabler : AosObjectBase
    
{
    [SerializeField] private GameObject _stone;
    [AosAction(name: "������� ��������� ������� true - �������, false - ���������")]
    public void SetCondition(bool value)
    {
        if (value == true)
            SceneSettings.Instance.Memory.Stone = true;
        else
        {
            SceneSettings.Instance.Memory.Stone = false;
            if (_stone == null)
                return;
            _stone.SetActive(false);
        }
            
    }
}
