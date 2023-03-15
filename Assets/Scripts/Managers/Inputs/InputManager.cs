using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Control de Inputs
public class InputManager : MonoBehaviour
{
    public bool shootButton;
    public Vector2 movementInput = Vector2.zero;
    public Vector2 rotationCanonInput = Vector2.zero;
  
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnRotation(InputAction.CallbackContext context)
    {
        rotationCanonInput = context.ReadValue<Vector2>();
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        shootButton = context.action.triggered;
    }
}
