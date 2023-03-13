using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float acceleratioInput, rotationInput;
    public bool shootButton;

    private void Update()
    {
        acceleratioInput = Input.GetAxisRaw("Vertical");
        rotationInput = Input.GetAxisRaw("Horizontal");
        shootButton = Input.GetKey(KeyCode.Q);
    }
}
