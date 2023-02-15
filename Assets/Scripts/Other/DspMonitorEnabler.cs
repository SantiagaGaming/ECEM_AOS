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

    private void Start()
    {
        if(_monitorEnabler.CurrentM==CurrentMonitor.MONITOR_1)
            OnOffMonitor(SceneSettings.Instance.Memory.Monitor1);
        else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_2)
            OnOffMonitor(SceneSettings.Instance.Memory.Monitor2);
        else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_3)
            OnOffMonitor(SceneSettings.Instance.Memory.Monitor3);
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
        if(value)
        {
            if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_1)
          {
                if (SceneSettings.Instance.Memory.Monitor1)
                    OnOffMonitor(SceneSettings.Instance.Memory.Monitor1);
          }
            else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_2)
            {
                if (SceneSettings.Instance.Memory.Monitor2)
                    OnOffMonitor(SceneSettings.Instance.Memory.Monitor2);
            }
            else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_3)
            {
                if (SceneSettings.Instance.Memory.Monitor3)
                    OnOffMonitor(SceneSettings.Instance.Memory.Monitor3);
            }
        }
        else
            OnOffMonitor(false);
    }
    public void OnTurnOnMonitor(bool value)
    {
        if (value)
        {
            if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_1)
            {
                if (SceneSettings.Instance.Memory.Monitor1Enabler)
                    OnOffMonitor(true);
            }
            else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_2)
            {
                if (SceneSettings.Instance.Memory.Monitor2Enabler)
                    OnOffMonitor(true);
            }
            else if (_monitorEnabler.CurrentM == CurrentMonitor.MONITOR_3)
            {
                if (SceneSettings.Instance.Memory.Monitor3Enabler)
                    OnOffMonitor(true);
            }
        }
        else
            OnOffMonitor(false);
    }
    private void OnOffMonitor(bool value)
    {
        if(value)
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
