using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public float velocity = 5;
    const int ANIMATION_CAMINAR = 1;
 private GameManagerController gameManager;
    private Rigidbody2D rb; // Cuerpo �f�sico� de los enemigos
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerController>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (velocity,0);
        ChangeAnimation(ANIMATION_CAMINAR);
        

    }
    private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado0", animation);
       

    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="Player" ){
          
            
           
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "loopEnemigoIzquierda"){
            velocity *= -1;
            ChangeAnimation(ANIMATION_CAMINAR);
            sr.flipX = false;    


        }
        if(other.gameObject.tag == "loopEnemigoDerecha"){
            velocity *= -1;
            ChangeAnimation(ANIMATION_CAMINAR);
              sr.flipX = true;  

        }
    }
}

