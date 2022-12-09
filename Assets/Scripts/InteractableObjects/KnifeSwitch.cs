using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSwitch : MonoBehaviour
{
    [SerializeField] private MovingButtonWithAction[] _handButtons;
    private void Start()
    {
        foreach (var handButton in _handButtons)
        {
            handButton.ButtonNumberEvent += OnChangeKnifePosition;
        }
    }
    public void OnChangeKnifePosition(int position)
    {
      
        if(CurrentAOSObject.Instance.SceneAosObject.ObjectId== "dsp_shvu_switch")
        {
            if (position == 0)
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            else if (position == 1)
                transform.localRotation = Quaternion.Euler(0, 0, -45);
            else if (position == 2)
                transform.localRotation = Quaternion.Euler(0, 0, 45);
        }
    }
}
