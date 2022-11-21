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
  if(SceneManager.GetActiveScene().name!="Menu")
        {
            _changer.OnTeleportToLocation("Menu");
        }
        else
        {
                _changer.OnTeleportToLocation(PlayerPrefs.GetString("PrevousSceneName"));
        }

    }

}
