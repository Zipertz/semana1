using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemigoloop : MonoBehaviour
{
    public float Velocity = 10;
    private Rigidbody2D _rb;
    private int enemigos_faltantes = 5;
    private SpriteRenderer _sr;
    private int cont1 = 0;
    private int cont2 = 0;


    private Payer _playerController;
    public void SetPlayerController(Payer playerController)
    {
        _playerController = playerController;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Enemigos.text = "Enemigos faltantes: " + enemigos_faltantes;
        if (_sr.flipX == true)
        {
            _rb.velocity = new Vector2(Velocity * -1, _rb.velocity.y);
        }
        if (_sr.flipX == false)
        {
            _rb.velocity = new Vector2(Velocity * 1, _rb.velocity.y);
        }
    }
}