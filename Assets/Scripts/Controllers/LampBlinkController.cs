using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlinkController : MonoBehaviour
{
    public static LampBlinkController Instance;
     private List<LampBlinker> _lamps;
    private void Awake()
    {
        if(Instance ==null)
            Instance = this;
        _lamps = new List<LampBlinker>();
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
    public void AddLampBlinker(LampBlinker blinker)
    {
        _lamps.Add(blinker);
    }
    private IEnumerator CoolDownBlink()
    {
        yield return new WaitForSeconds(0.5f);
        StartBlink();
    }
}
