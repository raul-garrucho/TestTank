using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        acceleratioInput = InputManager.acceleratioInput;
        rotationInput = InputManager.rotationInput;
        if (boostActive) BoostController();
        TankMovement();
    }
    private void TankMovement()
    {
        transform.Rotate(Vector3.up * rotationInput*rotationSpeed);//Rotacion
        if(rotationInput < 0.1f && rotationInput > -0.1f) rb.velocity = transform.forward * speed * acceleratioInput*speedModifier;//Move forward
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
