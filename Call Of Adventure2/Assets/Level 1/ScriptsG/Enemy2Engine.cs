using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Engine : MonoBehaviour
{
    float behoX;
    float distanceFromPlayer;
    float maxdistanceFromPlayer;
    public GameObject Player;
    Transform PlayerTrm;
    float playerX;
    public GameObject fire;
    Transform behotrm;
    float sideofshot;
    float Timer;
    bool isDead;
    Animator anm;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 2;
        maxdistanceFromPlayer = 8f;
        behotrm = gameObject.transform;
        Player = GameObject.Find("Player");
        PlayerTrm = Player.transform;
        anm = GetComponent<Animator>();
        isDead = false;


    }

    // Update is called once per frame
    void Update()
    {
        // timer so the shot wont be instiated nonstop
        Timer = Timer - (1 * Time.deltaTime);
        // way to see which side player is relative to beholder
        behoX = gameObject.transform.position.x;
        playerX = Player.transform.position.x;

        if (behoX < playerX)
        {
            gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);
            sideofshot = 0.5f;
        }
        else if (behoX > playerX)
        {
            gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);
            sideofshot = -0.5f;
        }
        else
        {
            gameObject.transform.localScale = gameObject.transform.localScale;
        }
        // shot instiniate and when
        distanceFromPlayer = Vector2.Distance(PlayerTrm.position, gameObject.transform.position);
        if (distanceFromPlayer < maxdistanceFromPlayer)
        {
            shootfire();
        }
    }
    public void shootfire()
    {
        if (Timer != 0 && isDead == false)
        {
            anm.SetBool("isShooting", false);

        }
        if (Timer <= 0 && isDead == false)
        {
            anm.SetBool("isShooting", true);
            Invoke("InstinateFire", 0.24f);
            Timer = 2;
            
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sowrd")
        {
            Destroy(gameObject, 0.4f);
            isDead = true;
            anm.SetTrigger("dead");
        }
    }

    public void InstinateFire()
    {
        Instantiate(fire, new Vector3(gameObject.transform.position.x + sideofshot, gameObject.transform.position.y + 0.1f, gameObject.transform.position.z), gameObject.transform.rotation);
    }
}