using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public float acceleratioInput, rotationInput;
    public bool shootButton;
    private Vector2 movementInput = Vector2.zero;
  
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        shootButton = context.action.triggered;
    }
    private void Update()
    {
        acceleratioInput = movementInput.y;
        rotationInput = movementInput.x;
       
    }
}
