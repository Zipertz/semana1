using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje_Programa : MonoBehaviour
{
    private GameManagerController gameManager;

    private int velocity   = 5;
    public int run_vel    = 10;
    public int jump_Force = 5;
    public GameObject shield;   
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;

    BoxCollider2D bc;

    const int Anima_Idle   = 0;
    const int Anima_Walk   = 1;
    const int Anima_Run    = 2;
    const int Anima_Attack = 3;
    const int Anima_Jump   = 4;
    const int Anima_jumpAttacl = 5;
    const int Anima_Dead   = 6;
    bool Ani_Salto = false;
    int aux = 0;
    int aux1 = 0;

    bool band = false;
    
    private Vector3 lastCheckpointPosition;
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Iniciando Script de Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          
        
        if(band == false){
        if (Input.GetKeyUp(KeyCode.Space)&& aux<2){
            //ChangeAnimation_Bool(Ani_Salto);
            rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
            aux++;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2 (velocity*2,0);
          rb.velocity = new Vector2(-run_vel, rb.velocity.y);
            sr.flipX = true;
            
            ChangeAnimation(Anima_Run);
        }

         if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(run_vel, rb.velocity.y);
            sr.flipX = false;
            
            ChangeAnimation(Anima_Run);
        }

        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
           sr.flipX = false;
            
            ChangeAnimation(Anima_Walk);
            
        }
         if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            
           sr.flipX = true;
           ChangeAnimation(Anima_Walk);
        }

        if (Input.GetKeyUp(KeyCode.A) && aux1<5){
            //Crear escudo
                var game = FindObjectOfType<GameManagerController>();
                
                var shieldPosition = transform.position + new Vector3(2,0,0);
                var gb = Instantiate(shield,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<AttEsc_Controller>();
                controller.SetRightDirection(); 
               game.perderBala(5);
                aux1++;
             }
             if(aux==1){
                ChangeAnimation(Anima_Jump);
            } 
        }else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(Anima_Dead);
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
 
        aux=0;
        if(other.gameObject.tag == "Enemy"){
            band = true;
            Destroy(this.gameObject, 2);
            Destroy(other.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Trigger");
        if(other.gameObject.tag == "pared"){
        rb.AddForce(new Vector2(0,jump_Force),ForceMode2D.Impulse);
        }
    }

    private void ChangeAnimation(int animation){     
        animator.SetInteger("Estado",animation);
    }
    private void ChangeAnimation_Bool(bool animat_bool){
        animator.SetBool("Saltar",animat_bool);
    }
    
}
