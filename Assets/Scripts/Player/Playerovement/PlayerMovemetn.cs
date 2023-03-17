using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Movimiento de los tanques
public class PlayerMovemetn : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Movement")]
    private float acceleratioInput, rotationInput;
    [Range(0,20)]public float speed, rotationSpeed, speedModifier;
    private InputManager InputManager;
    public float maxtime, actualtime;
    public bool boostActive;
   

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        InputManager = transform.GetComponent<InputManager>();
        boostActive = false;
    }
    private void FixedUpdate()
    {   
        TankMovement();
    }
    private void TankMovement()
    {
        if (boostActive) BoostController();
        //intenta recerear el movimiento de un tanque real, estos no pueden girar a la vez que avanzan.
        rotationInput =  InputManager.movementInput.x;

        rb.AddTorque(Vector3.up * rotationInput * rotationSpeed, ForceMode.VelocityChange);

        if(rotationInput == 0)
            rb.angularVelocity = Vector3.zero;        

        if (InputManager.movementInput.y != 0)
        {
            rb.AddForce(transform.forward * speed * InputManager.movementInput.y * speedModifier, ForceMode.VelocityChange);//Move forward
        }

    }
    private void BoostController()
    {
        actualtime += Time.deltaTime;
        if (actualtime>= maxtime)
        {
            speedModifier = 1;
            actualtime = 0;
            boostActive = false;
        }
    }
}
