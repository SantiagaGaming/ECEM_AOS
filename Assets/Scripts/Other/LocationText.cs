using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationText : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _locationText;
    private void Start()
    {
        _locationText.text = SceneSettings.Instance.Memory.LocationText;
    }
}
