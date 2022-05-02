using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // public GameManager gameManager;
    
    // Start is called before the first frame update
    [SerializeField]
    private int HP = 100;
    
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private GameObject bloofEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetInteger("HP",HP);
    }

    public void TakeDamage(int damage){
        HP -= damage;
        GetComponent<Animator>().SetTrigger("hurt");
        
        healthBar.SetHealthBar(HP);
        Instantiate(bloofEffect,transform.position,Quaternion.identity);
        Debug.Log(HP);
        if(HP<=0){
            Die();
        }
    }
    void Die(){
        gameObject.SetActive(false);
        // Destroy(this);          //刪除enwmy這個component
        // Destroy(gameObject);    //刪除enemy這個gameobject
        Debug.Log("DIE");
        GameManager.instance.GameOver();
        // gameManager.GameOver();
    }
}
