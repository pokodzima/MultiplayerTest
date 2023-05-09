using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class Projectile : SimulationBehaviour
{
    [SerializeField] private float _moveSpeed;

    const float DespawnTime = 5f;
    private float _despawnTimer;

    void OnEnable()
    {
        _despawnTimer = DespawnTime;
    }

    public override void FixedUpdateNetwork()
    {
        transform.Translate(Vector3.right * (_moveSpeed * Runner.DeltaTime), Space.Self);
        _despawnTimer -= Runner.DeltaTime;
        if (_despawnTimer <= 0f)
        {
            Runner.Despawn(Object);
        }
    }
}
