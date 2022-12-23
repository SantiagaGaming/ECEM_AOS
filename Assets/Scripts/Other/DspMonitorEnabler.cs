using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DspMonitorEnabler : MonoBehaviour
{
    public UnityAction<bool> OnEnableMonitor;
    [SerializeField] private MovingButtonWithAction _hand1;
    [SerializeField] private MovingButtonWithAction _hand2;
    [SerializeField] private MonitorEnabler _monitorEnabler;

    [SerializeField] private Canvas _offCanvas;
    [SerializeField] private Canvas _onCanvas;
    [SerializeField] private string _id;
    private void OnEnable()
    {
        _hand1.ButtonNumberEvent += OnMonitor;
        _hand2.ButtonNumberEvent += OnMonitor;
        if(_monitorEnabler!=null)
        _monitorEnabler.OnMonitorConditionChanged += OnStartMonitor;
    }
    private void OnDisable()
    {
        _hand1.ButtonNumberEvent -= OnMonitor;
        _hand2.ButtonNumberEvent -= OnMonitor;
        if (_monitorEnabler != null)
            _monitorEnabler.OnMonitorConditionChanged -= OnStartMonitor;
    }
    private void OnMonitor(int value)
    {
        if (CurrentAOSObject.Instance.SceneAosObject.ObjectId != _id)
            return;
        if (_monitorEnabler.CurrentM==CurrentMonitor.MONITOR_1 && SceneSettings.Instance.Memory.Monitor1Enabler)
        {
            EnablerMonitor(value);

        }
        else if(_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_2 && SceneSettings.Instance.Memory.Monitor2Enabler)
        {
            EnablerMonitor(value);
        }
        else if(_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_3 && SceneSettings.Instance.Memory.Monitor3Enabler)
        {
            EnablerMonitor(value);
        }
    }
    private void EnablerMonitor(int value)
    {
        if (value==1)
        {
            OnEnableMonitor?.Invoke(true);
            _onCanvas.enabled = true;
            _offCanvas.enabled = false;
        }
        else if(value == 0)
        {
            OnEnableMonitor?.Invoke(false);
            _onCanvas.enabled = false;
            _offCanvas.enabled = true;
        }
    }
    public void OnStartMonitor(bool value)
    {
            if (value)
            {
                _onCanvas.enabled = true;
                _offCanvas.enabled = false;
            }
            else
            {
                _onCanvas.enabled = false;
                _offCanvas.enabled = true;
            }
        }
    }
