using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscButton : MonoBehaviour
{
    private SceneChanger _changer;

    private void Start()
    {
        _changer = FindObjectOfType<SceneChanger>();
        SceneSettings.Instance.Memory.MenuEvent += OnShowMenu;
    }
    public void OnShowMenu()
    {
       _changer.TeleportToLocation(TagsHelper.MENU_LOCATION);
    }

}
