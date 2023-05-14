using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlTest : MonoBehaviour
{
    PlayerControls controls;

    void Awake()
    {
        controls = new PlayerControls();
        Debug.Log("22222222222222222");
        controls.Gameplay.Grow.performed += ctx => Grow();
        controls.Gameplay.Test.performed += ctx => Test();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void Grow()
    {
        Debug.Log("Pressed A");
        transform.localScale *= 1.1f;
    }
    void Test()
    {
        Debug.Log("Pressed B");
    }
}
