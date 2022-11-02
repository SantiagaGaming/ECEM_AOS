using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AosSdk.Core.PlayerModule.VRPlayer
{
    public class FadeController : MonoBehaviour
    {
        [SerializeField] private float _fadeSpeed = 1f;
        [SerializeField] private Renderer _fadeScreen;

        private Color _currentColor = new Color(0, 0, 0, 0);

        private float _fadeValue;

        private Transform _thisTransform;

        private Collider _headCollider;

        private struct CurrentColliding
        {
            public Collider Collider;
            public Vector3 Position;
            public Quaternion Rotation;
        }

        private readonly List<CurrentColliding> _currentColliding = new List<CurrentColliding>();

        private void OnEnable()
        {
            _fadeScreen.material.color = _currentColor;
            _thisTransform = transform;
            _headCollider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger)
            {
                return;
            }

            var colliderTransform = other.transform;

            var currentColliding = new CurrentColliding
            {
                Collider = other,
                Position = colliderTransform.position,
                Rotation = colliderTransform.rotation,
            };

            _currentColliding.Add(currentColliding);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.isTrigger)
            {
                return;
            }

            _currentColliding.Remove(_currentColliding.First(colliding => colliding.Collider == other));

            if (!_currentColliding.Any())
            {
                CameraFade(0);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.isTrigger)
            {
                return;
            }

            if (!_currentColliding.Any())
            {
                return;
            }

            var maxPenetration = 0f;

            foreach (var currentColliding in _currentColliding)
            {
                Physics.ComputePenetration(currentColliding.Collider, currentColliding.Position, currentColliding.Rotation, _headCollider, _thisTransform.position,
                    _thisTransform.rotation, out _, out var distance);
                maxPenetration = Mathf.Max(distance, maxPenetration);
            }

            CameraFade(Mathf.InverseLerp(0, 0.15f, maxPenetration));
        }

        private void LateUpdate()
        {
            if (!_currentColliding.Any())
            {
                CameraFade(0,true);
            }
        }

        private void CameraFade(float targetAlpha, bool isInstant = false)
        {
            _fadeValue = isInstant ? targetAlpha : Mathf.MoveTowards(_currentColor.a, targetAlpha, Time.fixedDeltaTime * _fadeSpeed);

            var material = _fadeScreen.material;

            _currentColor = material.color;
            _currentColor.a = _fadeValue;
            material.color = _currentColor;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.15f);
        }
    }
}