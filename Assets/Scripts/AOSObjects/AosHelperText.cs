using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosObject(name: "TextHelper")]
public class AosHelperText : AosObjectBase
{
    private string _helperText;
    [AosAction("������ ����� �������")]
    public void SetHelperText([AosParameter("������ �����")] string text)
    {
        _helperText = text;
    }
    public string GetHelperAosText() => _helperText;

}
