using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro.EditorUtilities;

public class SchemeImageChanger : MonoBehaviour, IClickAble
{
    [SerializeField] private Sprite[] _sprites;
    private int _curSprite;
    public bool IsClickable { get; set; } = true;
    private bool _active = false;
    public virtual void OnClicked(InteractHand interactHand)
    {
        ChangeSprite();
    }
    private void ChangeSprite()
    {
        _curSprite++;
        if (_curSprite > _sprites.Length - 1)
            _curSprite = 0;
        GetComponent<SpriteRenderer>().sprite = _sprites[_curSprite];
    }
    public void EnableImage(bool value)
    {
        gameObject.SetActive(value);
        _active = value;
    }
    public bool GetCondition()
    {
        return _active;
    }


}