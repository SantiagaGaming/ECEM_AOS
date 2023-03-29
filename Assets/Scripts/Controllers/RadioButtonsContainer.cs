using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RadioButtonsContainer : MonoBehaviour
{
    [SerializeField] private SceneAOSObject[] _radioButtons;
    public SceneAOSObject GetRadioButton(string name)
    {
        SceneAOSObject obj = _radioButtons.FirstOrDefault(b => b.ObjectId == name);
        if (obj != null)
            return obj;
        return null;
    }
}
