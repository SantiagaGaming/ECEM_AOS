using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnifeSwitch : MonoBehaviour
{
    public UnityAction<int> OnKnifePositionCjanged;
    [SerializeField] private MovingButtonWithAction[] _handButtons;
    private void Start()
    {
        foreach (var handButton in _handButtons)
        {
            handButton.ButtonNumberEvent += OnChangeKnifePosition;
        }
    }
    private void OnChangeKnifePosition(int position)
    {
        if(CurrentAOSObject.Instance.SceneAosObject.ObjectId== "dsp_shvu_switch")
        {
            if (position == 0)
                transform.localRotation = Quaternion.Euler(180, 0, 180);
            else if (position == 1)
                transform.localRotation = Quaternion.Euler(180, 0, -45);
            else if (position == 2)
                transform.localRotation = Quaternion.Euler(180, 0, 45);
            OnKnifePositionCjanged?.Invoke(position);
        }
    }
    public void OnStartChangeKnifePosition(int position)
    {
            if (position == 0)
                transform.localRotation = Quaternion.Euler(180, 0, 180);
            else if (position == 1)
                transform.localRotation = Quaternion.Euler(180, 0, -45);
            else if (position == 2)
                transform.localRotation = Quaternion.Euler(180, 0, 45);        
    }
}
