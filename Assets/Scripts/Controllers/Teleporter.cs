using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine.Events;


public class Teleporter : MonoBehaviour
{
    [SerializeField] private CameraFlash _cameraFlash;
    [SerializeField] private GameObject _descPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [SerializeField] private Transform _corridorFromFieldPosition;
    [SerializeField] private Transform _fieldPosition;
    [SerializeField] private Transform _corridorFromRelePosition;
    [SerializeField] private Transform _relePosition;
    [SerializeField] private Transform _corridorFromDspPosition;
    [SerializeField] private Transform _dspPosition;
    [SerializeField] private LocationTextController _locationText;

    private string _previousLocation;

    // [AosAction(name: "�������� � ��� �� �������� �����")]
    public void StartTeleport(string locationName)
    {
        if (locationName == "field" || locationName == "hall" || locationName == "dsp" || locationName == "relay_room")
        {
            if (locationName == "hall")
            {
                if (_previousLocation == "field")
                {
                    TeleportPlayer(_corridorFromFieldPosition);
                }
                else if (_previousLocation == "dsp")
                {
                    TeleportPlayer(_corridorFromDspPosition);
                }
                else if (_previousLocation == "relay_room")
                {
                    TeleportPlayer(_corridorFromRelePosition);
                }
            }
            if (_previousLocation != locationName)
            {
                _previousLocation = locationName;
                if (locationName == "field")
                {
                    TeleportPlayer(_fieldPosition);
                }
                else if (locationName == "dsp")
                {
                    TeleportPlayer(_dspPosition);
                }
                else if (locationName == "relay_room")
                {
                    TeleportPlayer(_relePosition);
                }
            }

        }



    }
    public void TeleportToDsp()
    {
        TeleportPlayer(_dspPosition);
    }
    // [AosAction(name: "�������� � ������� �� ��� �����")]
    public void TeleportToCorridorFromDsp()
    {
        TeleportPlayer(_corridorFromDspPosition);
    }
    // [AosAction(name: "�������� � ���� �� �������� �����")]
    public void TeleportToRele()
    {
        TeleportPlayer(_relePosition);
    }
    // [AosAction(name: "�������� � ������� �� ���� �����")]
    public void TeleportToCorridorFromRele()
    {
        TeleportPlayer(_corridorFromRelePosition);
    }
    // [AosAction(name: "�������� �� ���� �� �������� �����")]
    public void TeleportToField()
    {
        TeleportPlayer(_fieldPosition);
    }
    //  [AosAction(name: "�������� � ������� � ���� �����")]
    public void TeleportToCorridorFromStreet()
    {
        TeleportPlayer(_corridorFromFieldPosition);
    }

    private void TeleportPlayer(Transform newPosition)
    {
        Player.Instance.TeleportTo(newPosition);
        _descPlayer.transform.rotation = newPosition.rotation;
        _vrPlayer.transform.rotation = newPosition.rotation;
        _cameraFlash.CameraFlashStart();
    }

}
