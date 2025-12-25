using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{

    public float speed = 0.1f;
    public float maxSpeed = 0;
    public float minSpeed = 0;

    public float temporizadorAcelerar = 10;

    public Renderer motorDerecho;
    public Renderer motorIzquierdo;

    private Color colorOriginal;

    private bool acelerando = false;

    private Rigidbody rb;

    private void Awake()
    {
        colorOriginal = motorDerecho.material.color;
        maxSpeed = speed * 2;
        minSpeed = speed;
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
         applyRotation();
         applyMovement();
    }

    private void applyMovement()
    {
        if (Input.GetKey(KeyCode.Space)) { rb.AddForce(this.transform.forward * rb.mass * speed); }
    }

    private void applyRotation()
    {
        float sumarX = 0;
        float sumarY = 0;
        float sumarZ = 0;
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            sumarY = -1;
        } else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            sumarY = 1;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            sumarX = 1;
        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            sumarX = -1;
        }

        if (Input.GetKey(KeyCode.Q)) { 
            sumarZ = 1;
        } else if (Input.GetKey(KeyCode.E)) {
            sumarZ = -1;
        }

        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x + sumarY,
            transform.eulerAngles.y + sumarX,
            transform.eulerAngles.z + sumarZ
        );
    }

}
