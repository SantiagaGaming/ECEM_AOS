using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlinkController : MonoBehaviour
{
     public static LampBlinkController Instance;

     [SerializeField]private LampBlinker[] _lamps;
    private void Awake()
    {
        if(Instance ==null)
            Instance = this;

    }

    private void Start()
    {
        StartCoroutine(CoolDownBlink());
    }
    public void StartBlink()
    {
        foreach (var item in _lamps)
        {
            if(item.isActiveAndEnabled)
            item.EnableBlink(true);
        }
    }
    public void StopBlink()
    {
        foreach (var item in _lamps)
        {
            if (item.isActiveAndEnabled)
                item.EnableBlink(false);
        }
    }
    private IEnumerator CoolDownBlink()
    {
        yield return new WaitForSeconds(0.5f);
        StartBlink();
    }
}
