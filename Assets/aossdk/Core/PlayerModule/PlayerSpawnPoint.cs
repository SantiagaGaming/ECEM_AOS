using UnityEngine;

namespace AosSdk.Core.PlayerModule
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "../aossdk/Resources/pin.png", true);
        }
    }
}