using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "AosMeasureButton")]
public class MeasureAosButton : AosObjectBase
{
    [AosAction("���. ����. �������")]
    public void ActivateMeasureButton([AosParameter("��������� ������")] bool active)
    {
        Collider col = gameObject.GetComponent<Collider>();
        if (col != null)
            col.enabled = active;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(spriteRenderer !=null)
            spriteRenderer.enabled = active;
    }

}
