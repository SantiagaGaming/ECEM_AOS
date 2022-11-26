using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class StrelkaButton : BaseButton
{
    [SerializeField] private Side _currentSide;
    private enum Side
    {
        Plus,
        Minus,
        Indication

    }
    public override void OnClicked(InteractHand interactHand)
    {
        Diet diet = FindObjectOfType<Diet>();
        if(diet!=null)
        {
            if (_currentSide == Side.Plus)
            {
                diet.GetPlusID().InvokeOnClick();
                PlayerPrefs.SetString("Strelka", "plus");
            }
          
            else if (_currentSide == Side.Minus)
            {
                diet.GetMinusID().InvokeOnClick();
                PlayerPrefs.SetString("Strelka", "minus");
            }
               
            else if (_currentSide == Side.Indication)
                diet.GetIndicationID().InvokeOnClick();
        }
    }
}
