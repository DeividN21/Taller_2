using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del personaje
    private Rigidbody rb;
    private Animator anim; // Animator para animaciones de movimiento

    void Start()
    {
        // Obtener el componente Rigidbody del jugador
        rb = GetComponent<Rigidbody>();
        // Obtener el componente Animator del jugador
        anim = GetComponent<Animator>();
    }

    // FixedUpdate se llama en intervalos de tiempo fijos
    void FixedUpdate()
    {
        // Captura la entrada del teclado en el eje horizontal y vertical
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula el vector de movimiento en la perspectiva modificada (X como Z)
        Vector3 movement = new Vector3(-moveVertical, 0f, moveHorizontal) * speed * Time.fixedDeltaTime;

        // Aplica el movimiento al Rigidbody del jugador
        rb.MovePosition(rb.position + movement);

        // Si hay movimiento, rota el jugador para que mire en la dirección del movimiento
        if (movement != Vector3.zero)
        {
           // Calcula el ángulo de rotación en grados
            float targetAngle = Mathf.Atan2(-moveHorizontal, -moveVertical) * Mathf.Rad2Deg;

            // Aplica la rotación al jugador, teniendo en cuenta la perspectiva modificada
            // Intercambia los ejes X y Z en la rotación
            rb.MoveRotation(Quaternion.Euler(0f, targetAngle, 0f));

            // Anima el movimiento
            anim.SetBool("IsMoving", true);
        }
        else
        {
            // Si no hay movimiento, detiene las animaciones de movimiento
            anim.SetBool("IsMoving", false);
        }
    }
}


