using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RadioButtonsContainer : MonoBehaviour
{
    [SerializeField] private SceneAosObject[] _radioButtons;
    public SceneAosObject GetRadioButton(string name)
    {
        SceneAosObject obj = _radioButtons.FirstOrDefault(b => b.ObjectId == name);
        if (obj != null)
            return obj;
        return null;
    }
}
