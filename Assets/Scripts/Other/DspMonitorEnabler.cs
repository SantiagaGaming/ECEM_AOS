using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DspMonitorEnabler : MonoBehaviour
{
    [SerializeField] private MovingButtonWithAction _hand1;
    [SerializeField] private MovingButtonWithAction _hand2;

    [SerializeField] private Canvas _offCanvas;
    [SerializeField] private Canvas _onCanvas;
    private void OnEnable()
    {
        _hand1.ButtonNumberEvent += OnMonitor;
        _hand2.ButtonNumberEvent += OnMonitor;
    }
    private void OnDisable()
    {
        _hand1.ButtonNumberEvent -= OnMonitor;
        _hand2.ButtonNumberEvent -= OnMonitor;
    }
    public void OnMonitor(int value)
    {
        if (CurrentAOSObject.Instance.SceneAosObject.ObjectId != "dsp_workplace_mon1")
            return;
        if (value ==1)
        {
            _onCanvas.enabled = true;
            _offCanvas.enabled = false;
        }
        else if(value==0)
        {
            _offCanvas.enabled = true;
            _onCanvas.enabled = false;
        }
    }
}
