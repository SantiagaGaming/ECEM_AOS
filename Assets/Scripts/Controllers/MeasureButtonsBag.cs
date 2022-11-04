using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeasureButtonsBag : MonoBehaviour
{
    public static MeasureButtonsBag Instance;
    [SerializeField] private MeasureAosButton[] _measureButtons;
    public List<string> CurrentButtonsNames = new List<string>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ActivateMeasureButton(string name)
    {
        MeasureAosButton tempButton = _measureButtons.FirstOrDefault(n => n.ObjectId == name);
        if (tempButton != null)
            tempButton.ActivateMeasureButton(true);
        else Debug.Log("Measure Button with name not found " + name);
    }
    public void DeactivateAllButtons()
    {
        foreach (var item in _measureButtons)
        {
            item.ActivateMeasureButton(false);
        }
    }
    public void ActivateButtonsWithList()
    {
        foreach (var item in CurrentButtonsNames)
        {
            ActivateMeasureButton(item);
        }
    }

}
