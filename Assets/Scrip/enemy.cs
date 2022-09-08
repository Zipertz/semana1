using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public float velocity;
    const int ANIMATION_CAMINAR = 1;

    private Rigidbody2D rb; // Cuerpo �f�sico� de los enemigos
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (-velocity,0);
        ChangeAnimation(ANIMATION_CAMINAR);

    }
    private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado0", animation);
       

    }
}

