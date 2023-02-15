using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DspMonitorEnabler : MonoBehaviour
{
    public UnityAction<bool> OnEnableMonitor;
    [SerializeField] private MonitorEnabler _monitorEnabler;

    [SerializeField] private Canvas _offCanvas;
    [SerializeField] private Canvas _onCanvas;

    private bool _canEnable;
    private bool _isOn;
    private void Start()
    {
        if(_monitorEnabler.CurrentM==CurrentMonitor.MONITOR_1)
        {
           _isOn =  SceneSettings.Instance.Memory.Monitor1;
            _canEnable= SceneSettings.Instance.Memory.Monitor1Enabler;
            OnOffMonitor(_isOn);
        }
        else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_2)
        {
            _isOn = SceneSettings.Instance.Memory.Monitor2;
            _canEnable = SceneSettings.Instance.Memory.Monitor1Enabler;
            OnOffMonitor(_isOn);
        }
       else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_3)
        {
            _isOn = SceneSettings.Instance.Memory.Monitor3;
            _canEnable = SceneSettings.Instance.Memory.Monitor3Enabler;
            OnOffMonitor(_isOn);
        }
    }
    private void OnEnable()
    {
        if(_monitorEnabler!=null)
        {
            _monitorEnabler.OnMonitorConditionChanged += OnEnableMonitorCondition;
            _monitorEnabler.OnEnableMonitor += OnTurnOnMonitor;
        }
    }
    private void OnDisable()
    {
        if (_monitorEnabler != null)
        {
            _monitorEnabler.OnMonitorConditionChanged -= OnEnableMonitorCondition;
            _monitorEnabler.OnEnableMonitor -= OnTurnOnMonitor;
        }
    }
    public void OnEnableMonitorCondition(bool value)
    {
     _canEnable= value;
        if (!value)
            OnOffMonitor(false);
        else if(value && _isOn)
            OnOffMonitor(true);
    }
    public void OnTurnOnMonitor(bool value)
    {
       _isOn = value;
        if(_canEnable)
        {
            OnOffMonitor(value);
        }
        if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_1)
            SceneSettings.Instance.Memory.Monitor1 = value;
        else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_2)
            SceneSettings.Instance.Memory.Monitor2 = value;
        else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_3)
            SceneSettings.Instance.Memory.Monitor3 = value;

    }
    private void OnOffMonitor(bool value)
    {
        if(value && _canEnable)
        {
            _onCanvas.enabled = true;
            _offCanvas.enabled = false;
        }
        else
        {
            _offCanvas.enabled = true;
            _onCanvas.enabled = false;
        }
    }
    
    }
