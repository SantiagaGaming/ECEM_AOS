using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBlinkController : MonoBehaviour
{
     private List<LampBlinker> _lamps;
    private void Awake()
    {
        _lamps = new List<LampBlinker>();
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
