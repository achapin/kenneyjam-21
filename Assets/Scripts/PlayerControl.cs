using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private float steerAmount;

    public float SteerAmount => steerAmount;

    public void OnSteer(InputAction.CallbackContext context)
    {
        steerAmount = context.ReadValue<float>();
    }
}
