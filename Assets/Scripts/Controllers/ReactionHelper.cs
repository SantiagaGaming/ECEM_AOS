using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReactionHelper : MonoBehaviour
{
    [SerializeField] private GameObject _reactionHelperObject;
    [SerializeField] private TextMeshProUGUI _reactionText;

    public void EnableReactionHelper(bool value)
    {
        _reactionHelperObject.SetActive(value);
    }
    public void ChangeReactionHelperPosition(Transform newPos)
    {
        transform.position = newPos.position;
    }
    public void ChangeReactionHelperText(string text)
    {
        _reactionText.text = ControllersHandler.Instance.GetHtmlToText().HTMLToTextReplace(text);
    }
}
