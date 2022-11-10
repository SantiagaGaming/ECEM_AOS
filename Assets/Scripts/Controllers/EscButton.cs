using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class EscButton : MonoBehaviour
{
    [SerializeField] private InputActionProperty _menuAction;


    private bool _show = false;
    private void OnEnable()
    {
        _menuAction.action.performed += OnShowMenu;
    }
    private void OnDisable()
    {
        _menuAction.action.performed -= OnShowMenu;
    }
    private void OnShowMenu(InputAction.CallbackContext c)
    {
        if (!_show)
        {

            _show = true;
          //  _api.OnMenuInvoke();
        }
        else
        {
            _show = false;

        }

    }
    public void ChangeShowValue(bool value)
    {
        _show = value;
    }
}
