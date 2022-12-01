using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenController : MonoBehaviour
{
    [SerializeField] private MenuScreenView _menuScreenView;
    private string _tempMenuScreenObject;
    public static MenuScreenController Instance;
    private void Awake()
    {
        if(Instance ==null)
        Instance = this;
    }

    public void EnableMenuScreen(string value)
    {
        if(value !=TagsHelper.BACK)
        {
           _menuScreenView.ActivateMenuScreen(value);
            _tempMenuScreenObject = value;
        }
        else
        {
           if(_menuScreenView.GetCurrentScreenName()== TagsHelper.OTKAZI_INFO|| _menuScreenView.GetCurrentScreenName() == TagsHelper.OTKAZI || _menuScreenView.GetCurrentScreenName() == TagsHelper.EXIT)
            {
                _menuScreenView.ActivateMenuScreen(TagsHelper.MAIN);
            }
           else if(_menuScreenView.GetCurrentScreenName() == TagsHelper.UVK_LOCATION ||
                    _menuScreenView.GetCurrentScreenName() == TagsHelper.FIELD_LOCATION ||
                    _menuScreenView.GetCurrentScreenName() == TagsHelper.FEED_LOCATION ||
                _menuScreenView.GetCurrentScreenName() == TagsHelper.DSP_LOCATION ||
                _menuScreenView.GetCurrentScreenName() == TagsHelper.RELAY_LOCATION)
            {
                _menuScreenView.ActivateMenuScreen(TagsHelper.OTKAZI);
            }
        }
    }
}
