using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonesCellPlayer : MonoBehaviour
{

    public float JumpForce = 5;
    public float velocity = 10;
    int aux = 0;
    int aux1 = 0;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public GameObject bullet;
    private GameManagerController gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
         gameManager = FindObjectOfType<GameManagerController>();   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoverDerecha()
    {
          rb.velocity = new Vector2(velocity, rb.velocity.y);
           sr.flipX = false;

    }

    public void MoverIzquierda()
    {

         rb.velocity = new Vector2(-velocity, rb.velocity.y);
        
           sr.flipX = true;
    }

    public void Quieto()
    {

        rb.velocity = new Vector2(0, rb.velocity.y);
    }


    public void Saltar()
    {
        if(aux < 2)
        {
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            aux++;
        }
        
    }


    public void atacar()
    {
        if(aux1 < 5){
            var game = FindObjectOfType<GameManagerController>();
                //Crear escudo
                if(sr.flipX == false){
                
                    
                    var shieldPosition = transform.position + new Vector3(1,0,0);
                    var gb = Instantiate(bullet,
                                    shieldPosition,
                                    Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<bala>();
                    controller.SetRightDirection(); 
                    game.perderBala(5);
                    aux1++;
                }
                if(sr.flipX==true){
                    
                    
                    var shieldPosition = transform.position + new Vector3(-1,0,0);
                    var gb = Instantiate(bullet,
                                    shieldPosition,
                                    Quaternion.identity) as GameObject;
                    var controller =gb.GetComponent<bala>();
                    controller.SetLeftDirection(); 
                    game.perderBala(5);
                    aux1++;
                }
         
        }



    }








    void OnCollisionEnter2D(Collision2D other)
    {
        //puedeSaltar = false;
        aux=0;
    }
}
