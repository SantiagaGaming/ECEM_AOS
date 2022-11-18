using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DevelopSettings", menuName = "DevelopSettings", order = 1)]
public class DevelopSettings : ScriptableObject
{
    [SerializeField]
    public bool Develop;
}
