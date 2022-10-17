using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AosSdk.Core.PlayerModule.VRPlayer
{
    public class FadeController : MonoBehaviour
    {
        [SerializeField] private float _fadeSpeed = 1f;
        [SerializeField] private Material _fadeMaterial;

        private Color _currentColor = new Color(0, 0, 0, 0);

        private float _fadeValue;

        private Transform _thisTransform;

        private Collider _headCollider;

        private void OnEnable()
        {
            _fadeMaterial.color = _currentColor;
            _thisTransform = transform;
            _headCollider = GetComponent<Collider>();
        }

        private struct CurrentColliding
        {
            public Collider Collider;
            public Vector3 Position;
            public Quaternion Rotation;
        }

        private readonly List<CurrentColliding> _currentColliding = new List<CurrentColliding>();

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
                    _thisTransform.rotation, out var direction, out var distance);
                maxPenetration = Mathf.Max(distance, maxPenetration);
            }

            CameraFade(Mathf.InverseLerp(0, 0.15f, maxPenetration));
        }

        private void CameraFade(float targetAlpha)
        {
            _fadeValue = Mathf.MoveTowards(_currentColor.a, targetAlpha, Time.fixedDeltaTime * _fadeSpeed);

            _currentColor = _fadeMaterial.color;
            _currentColor.a = _fadeValue;
            _fadeMaterial.color = _currentColor;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.15f);
        }
    }
}