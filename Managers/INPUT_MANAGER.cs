using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INPUT_MANAGER : MonoBehaviour
{
    public static PlayerInputActionAsset playerInput;

    private void Awake()
    {
        playerInput = new PlayerInputActionAsset();
    }

    private void OnEnable()
    {
        playerInput.Enable();

    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
}
