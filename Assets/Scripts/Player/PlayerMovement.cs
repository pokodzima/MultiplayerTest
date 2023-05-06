using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerMovement : SimulationBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Vector2 _move;
    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority == false)
        {
            return;
        }

        _move.x = Input.GetAxis("Horizontal");
        _move.y = Input.GetAxis("Vertical");

        transform.Translate(_move * (Runner.DeltaTime * _moveSpeed));
    }
}
