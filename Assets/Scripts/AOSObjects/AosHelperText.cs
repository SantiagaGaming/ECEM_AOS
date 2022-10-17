using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosObject(name: "TextHelper")]
public class AosHelperText : AosObjectBase
{
    private string _helperText;
    [AosAction("Задать текст хелпера")]
    public void SetHelperText([AosParameter("Задать Текст")] string text)
    {
        _helperText = text;
    }
    public string GetHelperAosText() => _helperText;

}
