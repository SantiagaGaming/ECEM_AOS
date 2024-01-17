using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonUi : BaseUIButton
{
    private API _api;
    private const string EXIT = "exit";
    private void Start()
    {
       _api = FindObjectOfType<API>();
    }
    protected override void Click()
    {
        _api.OnNavActionInvoke(EXIT);
    }
}
