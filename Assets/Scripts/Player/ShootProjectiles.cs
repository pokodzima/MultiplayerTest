using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using Services;

public class ShootProjectiles : SimulationBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _spawnPosition;

    private bool _shooting;

    void Start()
    {
        ServiceLocator.Resolve<ShootButtonReference>()._shootButton.onClick.AddListener(Shoot);
    }
    public override void FixedUpdateNetwork()
    {
        if (!_shooting || !HasStateAuthority)
        {
            return;
        }

        Runner.Spawn(_projectilePrefab, _spawnPosition.position, Quaternion.LookRotation(_spawnPosition.forward, _spawnPosition.up));
        _shooting = false;
    }

    private void Shoot()
    {
        _shooting = true;
    }
}
