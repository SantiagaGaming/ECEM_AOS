using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;

public class BaseObject : MonoBehaviour, IClickAble, IHoverAble
{

    public bool Button;
    public bool IsHoverable { get; set; } = true;
    public bool IsClickable { get; set; } = true;

    protected CanvasObjectHelperController canvasHelper;
    protected SceneAosObject sceneAosObject;

    [SerializeField] protected OutlineCore[] outlineObjects;
    [SerializeField] protected Transform helperPos;
    [SerializeField] protected string helperName;

    protected Collider Collider;

    protected virtual void Start()
    {
        canvasHelper = FindObjectOfType<CanvasObjectHelperController>();
        Collider = GetComponent<Collider>();
        if (!Button)
        {
            if(Collider != null)
                Collider.enabled = false;
            ControllersHandler.Instance.GetAOSColliderActivator().AddBaseObject(this);
            sceneAosObject = GetComponent<SceneAosObject>();
        }
    }

    public virtual void OnClicked(InteractHand interactHand)
    {
        if(SceneSettings.Instance.CanTouch)
        {
            ControllersHandler.Instance.GetReactionHelper().EnableReactionHelper(false);
            ControllersHandler.Instance.GetReactionHelper().ChangeReactionHelperText("");
            sceneAosObject = GetComponent<SceneAosObject>();
            if (sceneAosObject != null)
            {
                sceneAosObject.InvokeOnClick();
                MovingButtonsController.Instance.ObjectName = sceneAosObject.ObjectId;
            }
            EnableOutlines(false);
        }
    }
    public virtual void OnHoverIn(InteractHand interactHand)
    {
        if(SceneSettings.Instance.CanTouch)
        {
            if (helperPos != null)
                canvasHelper.ShowTextHelper(helperName, helperPos);
            EnableOutlines(true);
        }
        else canvasHelper.HidetextHelper();

    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {
        if(SceneSettings.Instance.CanTouch)
        {
            if (helperPos != null && canvasHelper != null)
                canvasHelper.HidetextHelper();
            EnableOutlines(false);
        }
        else
        {
            canvasHelper.HidetextHelper();
        }

    }
    public void SetHelperName(string value)
    {
        helperName = ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(value);
    }
    public string GetAOSName()
    {
        if (GetComponent<AosObjectBase>() != null)
            return GetComponent<AosObjectBase>().ObjectId;
        else return null;
    }
    public virtual void EnableObject(bool value)
    {
        if (Collider != null)
            Collider.enabled = value;
        if (GetComponent<SpriteRenderer>())
            GetComponent<SpriteRenderer>().enabled = value;
    }
    protected void EnableOutlines(bool value)
    {
        if (outlineObjects != null)
            foreach (var outline in outlineObjects)
            {
                if (outline != null)
                {
                    outline.enabled = value;
                    outline.OutlineWidth = 3;
                }
            }
    }
}