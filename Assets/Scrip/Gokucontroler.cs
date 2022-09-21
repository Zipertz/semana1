using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gokucontroler : MonoBehaviour
{


Rigidbody2D rb;
SpriteRenderer sr;
private float gravityScale;
private Vector2 direction;
public int velocity = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
                
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        direction = new Vector2(x,y);

        if(Input.GetKey(KeyCode.UpArrow)){


            rb.velocity = new Vector2(rb.velocity.x,velocity);

            }

        if(Input.GetKey(KeyCode.DownArrow)){


            rb.velocity = new Vector2(rb.velocity.x,-velocity);

            }    



  



    }
    
     private void Run(){

            rb.velocity = new Vector2(direction.x*velocity,rb.velocity.y);
            sr.flipX = direction.x < 0;
        } 
}
