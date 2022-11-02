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
        StartBlink();
    }
    public void StartBlink()
    {
        foreach (var item in _lamps)
        {
            item.EnableBlink(true);
        }
    }
    public void StopBlink()
    {
        foreach (var item in _lamps)
        {
            item.EnableBlink(false);
        }
    }
    public void AddLampBlinker(LampBlinker blinker)
    {
        _lamps.Add(blinker);
    }
}
