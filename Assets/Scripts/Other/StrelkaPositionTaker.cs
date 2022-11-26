using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrelkaPositionTaker : MonoBehaviour
{
    [SerializeField]private Animator _sp6Anim;
    private void Start()
    {
        if (PlayerPrefs.GetString("Strelka") == "minus")
            _sp6Anim.SetTrigger("fastMinus");
        else if (PlayerPrefs.GetString("Strelka") == "plus")
            _sp6Anim.SetTrigger("fastPlus");
    }
}
