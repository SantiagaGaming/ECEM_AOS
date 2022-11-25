using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof (Image))]

public class AOSObjectWithImage : AosObjectBase
{
    private Image _img;
    private void Start()
    {
        _img= GetComponent<Image>();
        AOSImageContainer.Instance.AddAOSObjectWithImage(this);
    }
    public void DisableObject()
    {
        _img.enabled = false;
    }
    public void EnableObject(string name)
    {
        if(ObjectId==name)
            _img.enabled = true;
    }
}
