using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Payer : MonoBehaviour
{
    public float JumpForce = 5;
    public float velocity = 10;
    public float vcorrer = 20;

    public GameObject bullet;
    Rigidbody2D rb;
    
    SpriteRenderer sr;
    Animator animator;
    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_CAMINAR = 1;
    const int ANIMATION_CORRER = 2;
    const int ANIMATION_ATACAR = 3;
    const int ANIMATION_Saltar = 4;
    const int ANIMATION_MUERTE = 5;
    bool puedeSaltar = false;
    int aux = 0;
    int au = 0;
    public Transform PuntoDisparo;
    private Vector3 lastCheckPointPosition;
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
       
           // rb.velocity = new Vector2(0, rb.velocity.y);
            //ChangeAnimation(ANIMATION_QUIETO);  

      //  if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
        //{
            rb.velocity = new Vector2 (velocity*2,0);
          //rb.velocity = new Vector2(-vcorrer, rb.velocity.y);
           // sr.flipX = true;
            
            ChangeAnimation(ANIMATION_CORRER);
       // }

         if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(vcorrer, rb.velocity.y);
           // sr.flipX = false;
            
            ChangeAnimation(ANIMATION_CORRER);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
           // sr.flipX = false;
            
            ChangeAnimation(ANIMATION_CAMINAR);
            transform.eulerAngles = new Vector3(0,00,0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            
            
            
           transform.eulerAngles = new Vector3(0,180,0);
           //sr.flipX = true;
           ChangeAnimation(ANIMATION_CAMINAR);
        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeAnimation(ANIMATION_ATACAR);
           

        }
         if (Input.GetKeyDown(KeyCode.C) && au<5)
        
           Instantiate (bullet,PuntoDisparo.position,PuntoDisparo.rotation);
          
        {
            
        


        }
          if (Input.GetKeyDown(KeyCode.Space)  && aux<2)
        {
            
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_Saltar);
            puedeSaltar = true;
            aux++;
            
            

        }
       
   
       
        if (Input.GetKeyDown(KeyCode.P)) animator.SetTrigger("Muerto");
        {

        }
    }

 

    void OnCollisionEnter2D(Collision2D other)
    {
        puedeSaltar = false;
        aux=0;
        if (other.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("Muerto");
           ChangeAnimation(ANIMATION_MUERTE) ;
        }
        if (other.gameObject.name== "DarkHole")
        {
            if (lastCheckPointPosition !=null)
            {
                transform.position = lastCheckPointPosition;
            }
            
        }
       
    }



     void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Onco");
        if(other.gameObject.name == "Flecha_Cpoint"){
        lastCheckPointPosition = transform.position;
    }
        if(other.gameObject.name == "Cartel_Cpoint"){
            lastCheckPointPosition = transform.position;
        }

    }


    private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado0", animation);
       

    }
    private void cambioAnimation(bool anima)
    {
        animator.SetBool("puedeSaltar", anima);


    }
}
    
