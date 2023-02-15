using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DspMemory : MonoBehaviour
{
    [SerializeField] private PushableObjectWithMemory _key0;
    [SerializeField] private PushableObjectWithMemory _key3;
    [SerializeField] private DspMonitorEnabler _monitor1;
    [SerializeField] private DspMonitorEnabler _monitor2;
    [SerializeField] private DspMonitorEnabler _monitor3;
    [SerializeField] private KnifeSwitch _knife;
    private void Start()
    {
        if (SceneSettings.Instance.Memory.DspShvuKey0)
            _key0.PushInStrart();
        if(SceneSettings.Instance.Memory.DspShvuKey3)
            _key3.PushInStrart();
        _knife.OnStartChangeKnifePosition(SceneSettings.Instance.Memory.KnifePosition);
        _monitor1.OnEnableMonitorCondition(SceneSettings.Instance.Memory.Monitor1);
        _monitor2.OnEnableMonitorCondition(SceneSettings.Instance.Memory.Monitor2);
        _monitor3.OnEnableMonitorCondition(SceneSettings.Instance.Memory.Monitor3);
    }

    private void OnEnable()
    {
        _key0.OnPushed += OnPushSaveKey0;
        _key3.OnPushed += OnPushSaveKey3;
        _knife.OnKnifePositionCjanged += OnKnifePositionChanged;
        _monitor1.OnEnableMonitor += OnMonitor1EnabledChanged;
        _monitor2.OnEnableMonitor += OnMonitor2EnabledChanged;
        _monitor3.OnEnableMonitor += OnMonitor3EnabledChanged;
    }
    private void OnDisable()
    {
        _key0.OnPushed -= OnPushSaveKey0;
        _key3.OnPushed -= OnPushSaveKey3;
        _knife.OnKnifePositionCjanged -= OnKnifePositionChanged;
        _monitor1.OnEnableMonitor -= OnMonitor1EnabledChanged;
        _monitor2.OnEnableMonitor -= OnMonitor2EnabledChanged;
        _monitor3.OnEnableMonitor -= OnMonitor3EnabledChanged;
    }
    private void OnPushSaveKey0(bool value)
    {
        SceneSettings.Instance.Memory.DspShvuKey0 = value;
    }
    private void OnPushSaveKey3(bool value)
    {
        SceneSettings.Instance.Memory.DspShvuKey3 = value;
    }
    private void OnKnifePositionChanged(int value)
    {
        SceneSettings.Instance.Memory.KnifePosition= value;
    }
    private void OnMonitor1EnabledChanged(bool value)
    {
        SceneSettings.Instance.Memory.Monitor1 = value;
    }
    private void OnMonitor2EnabledChanged(bool value)
    {
        SceneSettings.Instance.Memory.Monitor2 = value;
    }
    private void OnMonitor3EnabledChanged(bool value)
    {
        SceneSettings.Instance.Memory.Monitor3 = value;
    }
}
