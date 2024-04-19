using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    private Animator animator;
    private bool caminando = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento hacia adelante y atrás
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            caminando = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
            caminando = true;
        }
        else
        {
            caminando = false;
        }

        // Rotación a la izquierda y derecha
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Actualizar el estado de la animación en el Animator Controller
        animator.SetBool("Caminando", caminando);
    }
}
