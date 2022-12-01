using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof (Image))]

public class AOSObjectWithImage : AosObjectBase
{
    [SerializeField]private Image[] _sameImages;
    private Image _img;
    private void Start()
    {
        _img= GetComponent<Image>();
        ControllersHandler.Instance.GetAOSImageContainer().AddAOSObjectWithImage(this);
    }
    public void DisableObject()
    {
        _img.enabled = false;
        SameImagesEnabler(false);
    }
    public void EnableObject(string name)
    {
        if(ObjectId==name)
        {
            _img.enabled = true;
            SameImagesEnabler(true);
        }
    }
    private void SameImagesEnabler(bool value)
    {
        if(_sameImages!=null)
        {
            foreach (var item in _sameImages)
            {
                item.GetComponent<Image>().enabled = value;
            }
        } 
    }
}
