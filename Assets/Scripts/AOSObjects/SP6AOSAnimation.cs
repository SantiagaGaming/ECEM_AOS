using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP6AOSAnimation : AosObjectBase
{
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    [AosAction(name: "��������� �������� ������ ��������� �����")]
    public void PlayRockEngineMinusAnim()
    {
        _anim.SetTrigger("otkazRockEngineMinus");
    }
    [AosAction(name: "��������� �������� ������ ��������� ����")]
    public void PlayRockEnginePlusAnim()
    {
        _anim.SetTrigger("otkazRockEnginePlus");
    }

    [AosAction(name: "��������� �������� ����")]
    public void PlayPlusAnim()
    {
        _anim.SetTrigger("plusAnim");
    }
    [AosAction(name: "��������� �������� �����")]
    public void PlayMinusAnim()
    {
        _anim.SetTrigger("minusAnim");
    }

}

