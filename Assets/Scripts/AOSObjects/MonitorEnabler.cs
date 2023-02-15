using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AosSdk.Core.Utils.AosObject(name: "MonitorEnabler")]

public class MonitorEnabler : SceneAosObject
{
    public UnityAction<bool> OnMonitorConditionChanged;
    public UnityAction<bool> OnEnableMonitor;

    [SerializeField] private CurrentMonitor _currentMonitor;
    public CurrentMonitor CurrentM => _currentMonitor;
    [AosAction(name: "Сменить состояние объекта")]
    public void SetCondition(bool condition)
    {
        if(_currentMonitor==CurrentMonitor.MONITOR_1)
        {
            SceneSettings.Instance.Memory.Monitor1Enabler = condition;
            OnMonitorConditionChanged?.Invoke(condition);
        }
       else if (_currentMonitor == CurrentMonitor.MONITOR_2)
        {
            SceneSettings.Instance.Memory.Monitor2Enabler = condition;
                OnMonitorConditionChanged?.Invoke(condition);
        }
       else if (_currentMonitor == CurrentMonitor.MONITOR_3)
        {
            SceneSettings.Instance.Memory.Monitor3Enabler = condition;
                OnMonitorConditionChanged?.Invoke(condition);
        }
    }

    [AosAction(name: "Сменить состояние объекта")]
    public void EnableMonitor(bool condition)
    {
        if (_currentMonitor == CurrentMonitor.MONITOR_1)
        {
            if(SceneSettings.Instance.Memory.Monitor1Enabler)
                OnEnableMonitor?.Invoke(condition);
        }
        else if(_currentMonitor == CurrentMonitor.MONITOR_2)
        {
            if (SceneSettings.Instance.Memory.Monitor2Enabler)
                OnEnableMonitor?.Invoke(condition);
        }
        else if (_currentMonitor == CurrentMonitor.MONITOR_3)
        {
            if (SceneSettings.Instance.Memory.Monitor3Enabler)
                OnEnableMonitor?.Invoke(condition);
        }
    }
}
public enum CurrentMonitor
{
    MONITOR_1,
    MONITOR_2,
    MONITOR_3
}

