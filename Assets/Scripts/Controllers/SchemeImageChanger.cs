using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SchemeImageChanger : MonoBehaviour, IClickAble
{
    private SchemeSpritesController _schemeSprites;
    private int _curSprite;
    public bool IsClickable { get; set; } = true;
    private bool _active = false;
    private void Start()
    {
        _schemeSprites = FindObjectOfType<SchemeSpritesController>();
        GetComponent<SpriteRenderer>().sprite = _schemeSprites.Sprites[_curSprite];
      transform.localScale = new Vector3(0.02f, 0.02f, 0.2f);
    }
    public virtual void OnClicked(InteractHand interactHand)
    {
        ChangeSprite();
    }
    private void ChangeSprite()
    {
        _curSprite++;
        if (_curSprite > _schemeSprites.Sprites.Length - 1)
            _curSprite = 0;
        GetComponent<SpriteRenderer>().sprite = _schemeSprites.Sprites[_curSprite];
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