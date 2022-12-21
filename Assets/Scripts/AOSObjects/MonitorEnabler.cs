using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AosSdk.Core.Utils.AosObject(name: "MonitorEnabler")]

public class MonitorEnabler : SceneAosObject
{
    public UnityAction<bool> OnMonitorConditionChanged;

    [SerializeField] private CurrentMonitor _currentMonitor;
    public CurrentMonitor CurrentM => _currentMonitor;
    [AosAction(name: "Сменить состояние объекта")]
    public void SetCondition(bool condition)
    {
        if(_currentMonitor==CurrentMonitor.MONITOR_1)
        SceneSettings.Instance.Memory.Monitor1Enabler = condition;
       else if (_currentMonitor == CurrentMonitor.MONITOR_2)
            SceneSettings.Instance.Memory.Monitor2Enabler = condition;
       else if (_currentMonitor == CurrentMonitor.MONITOR_3)
            SceneSettings.Instance.Memory.Monitor3Enabler = condition;
    }

    [AosAction(name: "Сменить состояние объекта")]
    public void EnableMonitor(bool condition)
    {
        if (_currentMonitor == CurrentMonitor.MONITOR_1)
        {
            SceneSettings.Instance.Memory.Monitor1 = condition;
            OnMonitorConditionChanged?.Invoke(condition);
        }
        else if(_currentMonitor == CurrentMonitor.MONITOR_2)
        {
            SceneSettings.Instance.Memory.Monitor2 = condition;
            OnMonitorConditionChanged?.Invoke(condition);
        }
        else if (_currentMonitor == CurrentMonitor.MONITOR_3)
        {
            SceneSettings.Instance.Memory.Monitor3 = condition;
            OnMonitorConditionChanged?.Invoke(condition);
        }
    }
}
public enum CurrentMonitor
{
    MONITOR_1,
    MONITOR_2,
    MONITOR_3
}

