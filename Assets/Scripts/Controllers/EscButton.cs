using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EscButton : MonoBehaviour
{
    private SceneChanger _changer;
    private void Start()
    {
        _changer = FindObjectOfType<SceneChanger>();
        AOSColliderActivator.Instance.Settings.MenuEvent += OnShowMenu;
    }
    private void OnShowMenu()
    {
            _changer.OnTeleportToLocation("menu");
    }

}
