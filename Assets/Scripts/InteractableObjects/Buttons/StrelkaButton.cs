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
            sceneAosObject = GetComponent<SceneAosObject>();
            if (_currentSide == Side.Plus)
                sceneAosObject.ObjectId = diet.GetPlusID();
            else if (_currentSide == Side.Minus)
                sceneAosObject.ObjectId = diet.GetMinusID();
            else if (_currentSide == Side.Indication)
                sceneAosObject.ObjectId = diet.GetIndicationID();
            sceneAosObject.InvokeOnClick();
            Debug.Log(sceneAosObject.ObjectId);
        }


    }
}
