using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DspMonitorEnabler : MonoBehaviour
{
    [SerializeField] private bool _monitor1;
    public UnityAction<bool> OnEnableMonitor;
    [SerializeField] private MovingButtonWithAction _hand1;
    [SerializeField] private MovingButtonWithAction _hand2;

    [SerializeField] private Canvas _offCanvas;
    [SerializeField] private Canvas _onCanvas;
    [SerializeField] private string _id;
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
    private void OnMonitor(int value)
    {
        if (CurrentAOSObject.Instance.SceneAosObject.ObjectId != _id)
            return;
        if (!_monitor1)
        {
            if (_offCanvas.isActiveAndEnabled)
            {
                OnEnableMonitor?.Invoke(true);
                _onCanvas.enabled = true;
                _offCanvas.enabled = false;
            }
            else
            {
                OnEnableMonitor?.Invoke(false);
                _onCanvas.enabled = false;
                _offCanvas.enabled = true;
            }

        }
        else if(_monitor1 && SceneSettings.Instance.Memory.Monitor1Enabler)
        {
            if (_offCanvas.isActiveAndEnabled)
            {
                OnEnableMonitor?.Invoke(true);
                _onCanvas.enabled = true;
                _offCanvas.enabled = false;
            }
            else
            {
                OnEnableMonitor?.Invoke(false);
                _onCanvas.enabled = false;
                _offCanvas.enabled = true;
            }
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
