using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class ChangeColorOnSpawn : NetworkBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Networked(OnChanged = nameof(AssignColor))] private Color _playerColor { get; set; }

    public override void Spawned()
    {
        if (!HasStateAuthority)
        {
            return;
        }


        _playerColor = Color.HSVToRGB(Random01(), Random01(), Random01());
    }

    private static void AssignColor(Changed<ChangeColorOnSpawn> changed)
    {
        changed.Behaviour._spriteRenderer.color = changed.Behaviour._playerColor;
    }

    private float Random01()
    {
        return Random.Range(0f, 1f);
    }
}
