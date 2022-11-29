using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOSImageContainer : MonoBehaviour
{
    public static AOSImageContainer Instance;
    private List<AOSObjectWithImage> _images = new List<AOSObjectWithImage>();
    private void Awake()
    {
        if (Instance==null)
            Instance = this;
    }
    public void AddAOSObjectWithImage(AOSObjectWithImage obj)
    {
        _images.Add(obj);
        Debug.Log(obj.ObjectId);
    }
    public AOSObjectWithImage GetAOSObjectWithImage(string name)
    {
        AOSObjectWithImage temp = _images.Find(x => x.ObjectId == name);
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
