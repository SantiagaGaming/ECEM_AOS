using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class StrelkaButton : BaseButton
{
    [SerializeField] private bool _side;
    public override void OnClicked(InteractHand interactHand)
    {
        StrelkaAOS strelka = FindObjectOfType<StrelkaAOS>();
        RadioButtonsContainer radioButtonsContainer = FindObjectOfType<RadioButtonsContainer>();
        LocationTextController locationTextController = FindObjectOfType<LocationTextController>();
        if (_side)
        {
            strelka.TrySwitchStrelkaPlus();
            AOSRadio button = radioButtonsContainer.GetButtonPlus(locationTextController.GetLocationName());
            button.InvokeOnClick();
        }

        else
        {
            strelka.TrySwitchStrelkaMinus();
            AOSRadio button = radioButtonsContainer.GetButtonMinus(locationTextController.GetLocationName());
            button.InvokeOnClick();
        }

    }
}
