using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed; // Velocidad del enemigo
    private Rigidbody2D rb; // Cuerpo “físico” de los enemigos
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position[0] < 5)
        {
            direction = 1; // Se moverán hacia la derecha
        }
        else if (transform.position[0] > 15)
        {
            
        direction = -1; // Se moverán hacia la izquierda
        }
        rb.velocity = new Vector3(direction * speed, 0.0f, 0.0f);
    }

}

