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
        AOSColliderActivator.Instance.Settings.MenuEvent += OnShowMenu;
        _backButton.onClick.AddListener(OnShowMenu);
    }
    private void OnShowMenu()
    {
            _changer.OnTeleportToLocation("menu");
    }

}
