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
    private void Update()
    {   
        TankMovement();
    }
    private void TankMovement()
    {
        if (boostActive) BoostController();
        //intenta recerear el movimiento de un tanque real, estos no pueden girar a la vez que avanzan.
        rotationInput =  InputManager.movementInput.x;
        transform.Rotate(Vector3.up * rotationInput*rotationSpeed);//Rotation
        if (rotationInput < 0.3f && rotationInput > -0.3f) rb.velocity = transform.forward * speed * InputManager.movementInput.y * speedModifier;//Move forward
        else rb.velocity = Vector3.zero;//Stop Movement
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
