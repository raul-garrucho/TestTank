using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Movimiento de los tanques
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
   
    private InputManager InputManager;
    private PlayerStats data;
    private Rigidbody rb;
  
    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        InputManager = transform.GetComponent<InputManager>();
        data = GetComponent<PlayerStats>();
    }
    private void FixedUpdate()
    {
        TankMovement();
    }
    private void TankMovement()
    {
       float rotationInput = InputManager.movementInput.x;
        rb.AddTorque(Vector3.up * rotationInput * rotationSpeed, ForceMode.VelocityChange);

        if (rotationInput == 0)
            rb.angularVelocity = Vector3.zero;

        rb.AddForce(transform.forward * speed * InputManager.movementInput.y * data.speedModifier, ForceMode.VelocityChange);//Move forward
    }
  
}
