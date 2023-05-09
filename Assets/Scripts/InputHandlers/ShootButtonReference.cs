using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services;

public class ShootButtonReference : MonoBehaviour
{
    public Button _shootButton { get; private set; }

    void Awake()
    {
        _shootButton = GetComponent<Button>();
        ServiceLocator.Register<ShootButtonReference>(this);
    }
}
