using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrelkaPositionTaker : MonoBehaviour
{
    [SerializeField]private Animator _sp6Anim;
    private void Start()
    {
        if (!SceneSettings.Instance.Memory.StrelkPosition)
        {
            _sp6Anim.SetTrigger("fastMinus");
        }

        else if (SceneSettings.Instance.Memory.StrelkPosition)
        {
            _sp6Anim.SetTrigger("fastPlus");
        }
    }
}
