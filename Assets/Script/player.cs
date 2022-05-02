using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //public SpriteRenderer spriteRenderer;
    public float speed = 5f;

    public float jumpForce = 100f;
    public Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.Space)){
            //(0,1,0)
            Jump();
        }


    }
    void Move(){

        Vector3 pos = transform.position;

        if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)){
            Debug.Log("move left");
            pos.x -= speed * Time.deltaTime;    
        }

        if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)){
            Debug.Log("move right");
            pos.x += speed * Time.deltaTime;
        }

        transform.position=pos;
    }
    void Jump(){
        rb2d.AddForce(Vector2.up*jumpForce);
    }
}
