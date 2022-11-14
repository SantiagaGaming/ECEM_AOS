using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Zoom : MonoBehaviour
{
    [SerializeField] private InputActionProperty _wheelAction;
    private Camera _camera;
    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }

    public bool CanZoom = true;

    private float _zoom;
    private void OnEnable()
    {
        _wheelAction.action.performed += OnMouseWheel;
    }
    private void OnDisable()
    {
        _wheelAction.action.performed -= OnMouseWheel;
    }
    public void ResetZoomCamera()
    {
        _camera.fieldOfView = 60;
    }
    private void OnMouseWheel(InputAction.CallbackContext obj)
    {
        if (CanZoom)
        {
            _zoom = obj.ReadValue<float>();
            if (_zoom < 0)
                _camera.fieldOfView = 60;
            else
                _camera.fieldOfView = 15;
        }
    }
}
