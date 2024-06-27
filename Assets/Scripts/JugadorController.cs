using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class JugadorController : MonoBehaviour
{
    public float jumpForce = 5f;
    private bool isGrounded;
    private Rigidbody rb;
    public float velocidad;
    public Text textoganar;
    private bool gameEnded = false;
    public float lanzar = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textoganar = GameObject.FindWithTag("TextoGanar").GetComponent<Text>();
        textoganar.text = "";
    }

    void Update()
    {

        if (!gameEnded)
        {
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            if (Input.GetMouseButtonDown(0))
            {
                LanzarBola();
            }
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if (!gameEnded)
        {
            float movimientoh = Input.GetAxis("Horizontal");
            float movimientov = Input.GetAxis("Vertical");
            Vector3 movimiento = new Vector3(movimientoh, 0.0f, movimientov);
            rb.AddForce(movimiento * velocidad);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!gameEnded)
        {
            if (other.gameObject.CompareTag("enemy"))
            {
                PerderJuego();
            }
            else if (other.gameObject.CompareTag("finish"))
            {
                Ganaste();
            }
        }
    }

    private void Ganaste()
    {
        textoganar.text = "¡Ganaste!";
        gameEnded = true;
    }

    void PerderJuego()
    {
        textoganar.text = "¡Perdiste!";
        gameEnded = true;
    }

    void LanzarBola()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero;

        Vector3 direccion = transform.forward + Vector3.up; 
        
        rb.AddForce(direccion * lanzar, ForceMode.Impulse);
    }
}
