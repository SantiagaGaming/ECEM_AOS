using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DspMemory : MonoBehaviour
{
    [SerializeField] private PushableObjectWithMemory _key0;
    [SerializeField] private PushableObjectWithMemory _key3;
    [SerializeField] private KnifeSwitch _knife;
    private void Start()
    {
        if (SceneSettings.Instance.Memory.DspShvuKey0)
            _key0.PushInStrart();
        if(SceneSettings.Instance.Memory.DspShvuKey3)
            _key3.PushInStrart();
        _knife.OnStartChangeKnifePosition(SceneSettings.Instance.Memory.KnifePosition);
    }

    private void OnEnable()
    {
        _key0.OnPushed += OnPushSaveKey0;
        _key3.OnPushed += OnPushSaveKey3;
        _knife.OnKnifePositionCjanged += OnKnifePositionChanged;
    }
    private void OnDisable()
    {
        _key0.OnPushed -= OnPushSaveKey0;
        _key3.OnPushed -= OnPushSaveKey3;
        _knife.OnKnifePositionCjanged -= OnKnifePositionChanged;
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
}
