using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Engine : MonoBehaviour
{
    public float bossSpeed;
    float distanceFromPlayer;
    float maxdistancefromPlayer;
    public Transform playerT;
    Transform PlayerTrm;
    public GameObject Player;
    float startBossX;
    float bossX;
    Animator anm;
    bool isDead;
    Rigidbody2D rb;

    //life
    public int bosslife;

    //shot
    float shotMaxdistancefromPlayer;
    float playerX;
    public GameObject fire;
    Transform behotrm;
    float sideofshot;
    float Timer;

    //Door avtivation
    public GameObject Door;


    void Start()
    {

        // life count
        bosslife = 3;
        //find Player Transform
        bossSpeed = 1;
        maxdistancefromPlayer = 4.5f;
        shotMaxdistancefromPlayer = 8f;
        Timer = 2;
        // starting Boss location & anm
        startBossX = gameObject.transform.position.x;
        anm = GetComponent<Animator>();
        isDead = false;
        Player = GameObject.Find("Player");
        PlayerTrm = Player.transform;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // new Boss location
        bossX = gameObject.transform.position.x;

        distanceFromPlayer = Vector2.Distance(playerT.position, gameObject.transform.position);

        if (distanceFromPlayer < maxdistancefromPlayer && isDead == false)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, playerT.position, bossSpeed * Time.deltaTime);
            maxdistancefromPlayer = 20;


        }
        // move and scale
        if (bossX < startBossX)
        {
            gameObject.transform.localScale = new Vector2(-1, transform.localScale.y);
            startBossX = bossX;
        }
        if (bossX < startBossX)
        {
            gameObject.transform.localScale = new Vector2(1, transform.localScale.y);
            startBossX = bossX;
        }

        // timer so the shot wont be instiated nonstop
        Timer = Timer - (1 * Time.deltaTime);
        // way to see which side player is relative to beholder
        bossX = gameObject.transform.position.x;
        playerX = Player.transform.position.x;

        if (bossX < playerX)
        {
            gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);
            sideofshot = 1f;
        }
        else if (bossX > playerX)
        {
            gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);
            sideofshot = -1f;
        }
        else
        {
            gameObject.transform.localScale = gameObject.transform.localScale;
        }
        // shot instiniate and when
        distanceFromPlayer = Vector2.Distance(PlayerTrm.position, gameObject.transform.position);
        if (distanceFromPlayer < shotMaxdistancefromPlayer)
        {
            shootfire();
        }
        // deathcon
        if(bosslife == 0)
        {
            Door.GetComponent<Scene1Maneger>().isBossDead = true; 
            anm.SetTrigger("dead");
            Destroy(gameObject, 0.9f);
        }
    }

    public void shootfire()
    {
        if (Timer != 0 && isDead == false)
        {
            anm.SetBool("isHurtting", false);
            anm.SetBool("isAtking", false);
        }
        if (Timer <= 0 && distanceFromPlayer > 1)
        {
            Instantiate(fire, new Vector3(gameObject.transform.position.x + sideofshot, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
            Timer = 2;
            anm.SetBool("isHurtting", false);
            anm.SetBool("isAtking", true);
        }
    }
    
    // hurt anm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sowrd"))
        {
            bosslife--;
            anm.SetBool("isHurtting", true);
            anm.SetBool("isAtking", false);
        }
     
    }
    
    
}