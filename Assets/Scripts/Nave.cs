using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{

    public float velocidad = 0.1f;
    public float multiplicadorBoost = 1;
    public float temporizadorAcelerar = 10;

    public Renderer motorDerecho;
    public Renderer motorIzquierdo;

    private Color colorOriginal;

    private bool acelerando = false;

    private Rigidbody rb;

    private float maxSpeed = 0;
    private float minSpeed = 0;

    private void Awake()
    {
        colorOriginal = motorDerecho.material.color;
        maxSpeed = velocidad * multiplicadorBoost;
        minSpeed = velocidad;
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
         applyRotation();
         applyMovement();
    }

    private void applyMovement()
    {
        float currentSpeed = 0;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            currentSpeed = Input.GetKey(KeyCode.LeftShift) ? maxSpeed : minSpeed;
        } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            currentSpeed = minSpeed * -1;
        }

        rb.AddForce(this.transform.forward * rb.mass * currentSpeed);

    }

    private void applyRotation()
    {
        float anguloX = 0;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            anguloX = 1;
        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            anguloX = -1;
        }

        transform.Rotate(new Vector3(0, anguloX, 0));
    }

}
