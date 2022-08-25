using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payer : MonoBehaviour
{
    public float velocity = 10,jumpForce = 5 ;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    const int ANIMACION_QUIETO=0;
    const int ANIMACION_CAMINAR=1;
    const int ANIMACION_CORRER=2;
    const int ANIMACION_ATACAR =3;
    const int ANIMACION_SALTAR =4;
     bool puedaSaltar = true;
    // Start is called before the first frame update
    void Start()
    {
       
        Debug.Log("Este es un mensaje de log");

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
       
          
    }

    // Update is called once per frame
    void Update()
    {
      
        rb.velocity = new Vector2(0,rb.velocity.y);
        cambioanimacion(ANIMACION_QUIETO);

        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(velocity,rb.velocity.y);
            sr.flipX=false;
            cambioanimacion(ANIMACION_CORRER);   
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-velocity,rb.velocity.y);
            sr.flipX=true;  
            cambioanimacion(ANIMACION_CAMINAR);
         }
        else if(Input.GetKey(KeyCode.X)){
            rb.velocity = new Vector2(velocity,rb.velocity.y);
            sr.flipX=true;  
            cambioanimacion(ANIMACION_CORRER);
         }

        if(Input.GetKey(KeyCode.Z)){ 
            cambioanimacion(ANIMACION_ATACAR);
         }

        if (Input.GetKeyUp(KeyCode.Space)  && puedaSaltar)
        {
            rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            puedaSaltar =  false;
            cambioanimacion(ANIMACION_SALTAR);
        }
        
    }
    void OnCollisionEnter2D(Collision2D other)
     {  // saber cuando colsiona
        puedaSaltar = true;
      
    }

 

    private void cambioanimacion(int animation){ // animaciones de caminar y quieto
        animator.SetInteger("Estado0", animation);
    }
}
