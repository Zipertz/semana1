using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttEsc_Controller : MonoBehaviour
{
    public float velocity = 20;
    private GameManagerController gameManager;
    Rigidbody2D rb;
    // Start is called before the first frame update
    float realVelocity;
    public void SetRightDirection(){
        realVelocity = velocity;
    }
    public void SetLeftDirection(){
        realVelocity = -velocity;
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerController>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(realVelocity,0);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="Enemy" ){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
           
        }
    }
     
}