using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "Текст Локации")]
public class LocationTextController : AosObjectBase
{
    [SerializeField] private TextMeshProUGUI _deskText;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private API _api;
    private string _currentLocation = "field";
    private void Start()
    {
        _deskText.text = "Поле";
        _textMesh.text = "Поле";
    }

    public void SetLocationText(string location)
    {
        _deskText.text = location;
        _textMesh.text = location;
    }
    public void SetLocation(string location)
    {
        _currentLocation = location;
        _api.SetLocation();
    }
    public void SetLocationT(string location)
    {
        _currentLocation = location;

    }
    public string GetLocationName()
    {
        return _currentLocation;
    }


}
