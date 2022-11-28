using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsResetter : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetString("MenuScene", "");
        PlayerPrefs.SetString("Teleport", "");
        PlayerPrefs.SetString("Strelka", "");
        PlayerPrefs.SetString("Stone", "false");
    }

}
