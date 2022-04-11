using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinEngine : MonoBehaviour
{
    public float goblinspeed;
    float distanceFromPlayer;
    float maxdistancefromPlayer;
    float attackRange;
    public Transform player;
    float StartgobX;
    float gobX;
    Animator anm;
    Rigidbody2D RB;
    float shovedir;
    bool isAtk;
    
    void Start()
    {
        goblinspeed = 2;
        maxdistancefromPlayer = 4.5f;
        // starting goblin location
        StartgobX = gameObject.transform.position.x;
        anm = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        isAtk = false;
        attackRange = 0.55f;
    }

  
    void Update()
    {
        // new goblin location
        gobX = gameObject.transform.position.x;

        distanceFromPlayer = Vector2.Distance(player.position, gameObject.transform.position);
       //AI
            if (distanceFromPlayer < maxdistancefromPlayer && isAtk == false)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, goblinspeed * Time.deltaTime);
            maxdistancefromPlayer = 20;

            anm.SetBool("isGobWalking", true);
            anm.SetBool("isGobAttack", false);
            anm.SetBool("isGobHirt", false);
        }
        //facing 
        if (gobX < StartgobX && isAtk == false)
        {
            gameObject.transform.localScale = new Vector2(-1, transform.localScale.y);
            StartgobX = gobX;
            anm.SetBool("isGobWalking", true);
            anm.SetBool("isGobAttack", false);
            anm.SetBool("isGobHirt", false);
            shovedir = 80;

        }
        if (gobX > StartgobX && isAtk == false)
        {
            gameObject.transform.localScale = new Vector2(1, transform.localScale.y);
            StartgobX = gobX;
            anm.SetBool("isGobWalking", true);
            anm.SetBool("isGobAttack", false);
            anm.SetBool("isGobHirt", false);
            shovedir = -80;
        }
        // if nothing
        if (gobX == StartgobX)
        {
            anm.SetBool("isGobWalking", false);
            anm.SetBool("isGobAttack", false);
            anm.SetBool("isGobHirt", false);

        }
        // when to attack
       if (distanceFromPlayer < attackRange)
        {
            isAtk = true;
            anm.SetBool("isGobWalking", false);
            anm.SetBool("isGobAttack", true);
            anm.SetBool("isGobHirt", false);
        }
       // when to stop attacking
       if (distanceFromPlayer > attackRange)
        {
            isAtk = false;
            anm.SetBool("isGobWalking", true);
            anm.SetBool("isGobAttack", false);
            anm.SetBool("isGobHirt", false);
        }
      
          
           
        
     

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sword"))
        {
            anm.SetTrigger("GobDeath");
            RB.AddForce(new Vector2(shovedir, 0));
            Destroy(gameObject, 0.3f);
        }
       
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            anm.SetTrigger("GobDeath");
            Destroy(gameObject, 0.3f);
        }
        if (collision.gameObject.tag == "Acid")
        {
            anm.SetTrigger("GobDeath");
            Destroy(gameObject, 0.3f);
        }
    }
}
