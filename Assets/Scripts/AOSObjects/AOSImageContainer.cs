using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AOSImageContainer : MonoBehaviour
{
    [SerializeField]private AOSObjectWithImage[] _images;

    public AOSObjectWithImage GetAOSObjectWithImage(string name)
    {
        if (_images == null)
            return null;
        AOSObjectWithImage temp = _images.FirstOrDefault(x => x.ObjectId == name);
        if(temp!=null)
            return temp;
        else return null;
    }
    public void DeactivateAllImages()
    {
        foreach (var obj in _images)
        {
            if(obj!=null)
            obj.DisableObject();
        }
    }
}
