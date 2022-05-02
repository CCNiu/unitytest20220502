using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBandit : MonoBehaviour
{   
    private float speed = 10f;
    private float jumpForce=500f;

    private bool isGrounded = true;
    [SerializeField]
    private int damage = 20;

    float nextattacktime;
    float attackrate= 2f;
    public Transform attackpoint;

    public float attackradius;

    public LayerMask enemyLayer;

    public Animator animator;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        rb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        float movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement*speed*Time.deltaTime,0,0);
        

        //Jump
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.UpArrow)){
            // if(Mathf.Abs(rb2d.velocity.y)< 0.01)
            if(isGrounded==true)
                rb2d.AddForce(Vector2.up*jumpForce); 
        }

        //FilpX
        if(movement!=0)
            transform.localScale = new Vector3(-movement,1,1);

        //Run Animation
        animator.SetFloat("velocity",Mathf.Abs( movement * speed));

        //Attack
        if(Input.GetMouseButtonDown(0)){
            if(nextattacktime < Time.time){
            Attack();
            nextattacktime=Time.time + 1 / attackrate;
            }
        }
            


    }
    void Attack(){
        //動畫
        animator.SetTrigger("attack");

        //造成傷害
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackpoint.position,attackradius,enemyLayer);

        foreach(var enemy in enemies){
            // Debug.Log(enemy.name);
            // enemy.enabled = false;
            // enemy.gameObject.SetActive(false);
            // enemy.gameObject.GetComponent<Enemy>().HP -= 10;
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpoint.position,attackradius);
    }
    //void Move(){
        //  Vector3 pos = transform.position;

        // if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)){
        //     Debug.Log("move left");
        //     pos.x -= speed * Time.deltaTime;    
        // }

        // if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)){
        //     Debug.Log("move right");
        //     pos.x += speed * Time.deltaTime;
        // }

        // // transform.position=pos;
        // rb2d.MovePosition(pos);


        // float velocity = rb2d.velocity.magnitude;
        // Debug.Log(velocity);
    //}
    // void Jump(){
    //     rb2d.AddForce(Vector2.up*jumpForce);
    // }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name=="Ground")
            isGrounded = true;
            // Debug.Log(other.gameObject.name);
    } 
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.name=="Ground")
            isGrounded = false;
            // Debug.Log(other.gameObject.name);
    } 
}
