using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscButton : MonoBehaviour
{
    private SceneChanger _changer;
    [SerializeField] private Button _backButton;
    private void Start()
    {
        _changer = FindObjectOfType<SceneChanger>();
        SceneSettings.Instance.Memory.MenuEvent += OnShowMenu;
        if(_backButton!=null)
        _backButton.onClick.AddListener(OnShowMenu);
    }
    public void OnShowMenu()
    {
       _changer.TeleportToLocation(TagsHelper.MENU_LOCATION);
    }

}
