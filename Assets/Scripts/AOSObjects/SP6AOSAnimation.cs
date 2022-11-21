using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "SP6_anim")]
public class SP6AOSAnimation : AosObjectBase
{
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    [AosAction(name: "Проиграть анимацию Камень двигатель минус")]
    public void PlayRockEngineMinusAnim()
    {
        _anim.SetTrigger("otkazRockEngineMinus");
    }
    [AosAction(name: "Проиграть анимацию Камень двигатель плюс")]
    public void PlayRockEnginePlusAnim()
    {
        _anim.SetTrigger("otkazRockEnginePlus");
    }

    [AosAction(name: "Проиграть анимацию плюс")]
    public void PlayPlusAnim()
    {
        _anim.SetTrigger("plusAnim");

    }
    [AosAction(name: "Проиграть анимацию минус")]
    public void PlayMinusAnim()
    {
        _anim.SetTrigger("minusAnim");
        Debug.Log("Played");
    }

}

