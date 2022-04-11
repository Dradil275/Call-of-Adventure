using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Engine : MonoBehaviour
{
    public float enemy1Speed;
    float distanceFromPlayer;
    float maxdistancefromPlayer;
    public Transform player;
    float startEnemy1X;
    float enemy1X;
    Animator anm;
    bool isDead;
  

    void Start()
    {
        //find Player Transform
        enemy1Speed = 1;
        maxdistancefromPlayer = 4.5f;
        // starting Enemy1 location
        startEnemy1X = gameObject.transform.position.x;
        anm = GetComponent<Animator>();
        isDead = false;
        
    }


    void Update()
    {
        // new Enemy1 location
        enemy1X = gameObject.transform.position.x;

        distanceFromPlayer = Vector2.Distance(player.position, gameObject.transform.position);

        if (distanceFromPlayer < maxdistancefromPlayer && isDead == false)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, enemy1Speed * Time.deltaTime);
            maxdistancefromPlayer = 20;


        }
        
        if (enemy1X < startEnemy1X)
        {
            gameObject.transform.localScale = new Vector2(-1, transform.localScale.y);
            startEnemy1X = enemy1X;
            


        }
        if (enemy1X > startEnemy1X)
        {
            gameObject.transform.localScale = new Vector2(1, transform.localScale.y);
            startEnemy1X = enemy1X;

           
        }
        /*
        if (enemy1X == startEnemy1X)
        {
            
        }  */

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sowrd")
        {
            isDead = true;
            Destroy(gameObject, 0.4f);
            anm.SetTrigger("dead");
        }
    }

    
}
