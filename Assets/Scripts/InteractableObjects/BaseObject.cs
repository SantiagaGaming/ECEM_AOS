using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;
using AosSdk.Core.PlayerModule.Pointer;

public class BaseObject : MonoBehaviour, IClickAble, IHoverAble
{

    public bool IsHoverable { get; set; } = true;
    public bool IsClickable { get; set; } = true;


    protected CanvasObjectHelperController canvasHelper;


    [SerializeField] protected OutlineCore[] outlineObjects;
    [SerializeField] protected Transform helperPos;
    [SerializeField] protected string helperName;

    protected virtual void Start()
    {
        canvasHelper = FindObjectOfType<CanvasObjectHelperController>();


    }

    public virtual void OnClicked(InteractHand interactHand)
    {


    }
    public virtual void OnHoverIn(InteractHand interactHand)
    {
 
            if (helperPos != null)
                canvasHelper.ShowTextHelper(helperName, helperPos);
            if (outlineObjects != null)
                foreach (var obj in outlineObjects)
                {
                    obj.enabled = true;
                    obj.OutlineWidth = 3;
                }

    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {

            if (helperPos != null)
                canvasHelper.HidetextHelper();
            if (outlineObjects != null)
                foreach (var obj in outlineObjects)
                {
                    obj.enabled = false;
                    obj.OutlineWidth = 0;
                }

    }
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
    public void SetHelperName(string value)
    {
        helperName = value;
    }

}