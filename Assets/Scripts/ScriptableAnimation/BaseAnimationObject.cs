using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimationObject : MonoBehaviour, IScriptableAnimationObject
{
    [HideInInspector] public bool CanOpen = true;
    protected bool IsClosed = true;
    protected bool CanRotate = true;

    public  virtual void PlayScritableAnimtaion()
    {
      
    }

}
