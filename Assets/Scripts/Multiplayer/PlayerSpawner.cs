using Fusion;
using UnityEngine;

namespace Multiplayer
{
    public class PlayerSpawner : NetworkBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;

        public override void Spawned()
        {
            if (!Runner)
            {
                return;
            }
            Runner.Spawn(_playerPrefab, new Vector3(0, 1, 0), Quaternion.identity, Runner.LocalPlayer);
        }
    }
}