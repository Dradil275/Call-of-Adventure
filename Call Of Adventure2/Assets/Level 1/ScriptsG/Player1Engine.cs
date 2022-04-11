using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Engine : MonoBehaviour
{
    float x;
    float speed;
    float shovedir;
    public GameObject ladders;
    public GameObject fire;
    public bool climb;
    bool isFloor;
    bool isDead;
    private float vertical;
    private float climbspeed = 5f;
    private bool isLadder;
    private bool isClimbing;
    public int life;
    int oldlife;
    Animator anm;
    public GameObject SceneManeger;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        speed = 5f;
        climb = false;
        isFloor = true;
        isDead = false;
        SceneManeger = GameObject.Find("SceneManeger");
        //active animator component
        anm = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(x, 0, 0);
        }


        // if standing anm noting
        if (0 == x && isFloor == true)
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isJumping", false);
            anm.SetBool("isClaimbing", false);
            anm.SetBool("isHurting", false);
            anm.SetBool("isMeele", false);
        }
        // if walking left walk left
        else if (0 > x)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
            shovedir = 200;
            if (isFloor == true)
            {
                anm.SetBool("isWalking", true);
                anm.SetBool("isJumping", false);
                anm.SetBool("isClaimbing", false);
                anm.SetBool("isHurting", false);
                anm.SetBool("isMeele", false);
            }
        }
        // if walking right walk right
        else if (0 < x)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
            shovedir = -200;
            if (isFloor == true)
            {
                anm.SetBool("isWalking", true);
                anm.SetBool("isJumping", false);
                anm.SetBool("isClaimbing", false);
                anm.SetBool("isHurting", false);
                anm.SetBool("isMeele", false);
            }

        }

        if (Input.GetKeyDown(KeyCode.W) && isFloor == true)
        {
            rb.AddForce(new Vector2(0, 300f));

            // active JumpAnm
            anm.SetBool("isWalking", false);
            anm.SetBool("isJumping", true);
            anm.SetBool("isClaimbing", false);
            anm.SetBool("isHurting", false);
            anm.SetBool("isMeele", false);

            isFloor = false;
        }
        //if falling from ladder to ground
        if(isFloor == false && isLadder == false)
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isJumping", true);
            anm.SetBool("isClaimbing", false);
            anm.SetBool("isHurting", false);
            anm.SetBool("isMeele", false);
        }
        //small tab on W make it jump less
        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0 && isDead == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        //ATK Act + Anm
        if (Input.GetKey(KeyCode.F))
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isJumping", false);
            anm.SetBool("isClaimbing", false);
            anm.SetBool("isHurting", false);
            anm.SetBool("isMeele", true);
        }
        if(life > 10)
        {
            life = 10;
        }

        vertical = Input.GetAxis("Vertical");

        if (isLadder == true && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
            anm.SetBool("isWalking", false);
            anm.SetBool("isJumping", false);
            anm.SetBool("isClaimbing", true);
            anm.SetBool("isHurting", false);
            anm.SetBool("isMeele", false);
        }
        // hurt animation
        if(life < oldlife)
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isJumping", false);
            anm.SetBool("isClaimbing", false);
            anm.SetBool("isHurting", true);
            anm.SetBool("isMeele", false);
        }
        oldlife = life;
        //death condition
        if(life == 0)
        {
            anm.SetTrigger("dead");
            SceneManeger.GetComponent<SceneManegerLVL1>().gameover = true;
            Destroy(gameObject, 0.7f);
            
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing == true)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * climbspeed);
        }

        if (isClimbing == false)
        {
            rb.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders"))
        {
            isLadder = true;
            Debug.Log("isladder true");
        }
        if(collision.CompareTag("Health") && life < 10)
        {
            life++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Enemy2S") || collision.CompareTag("BossShot"))
        {
            anm.SetBool("isWalking", false);
            anm.SetBool("isJumping", false);
            anm.SetBool("isClaimbing", false);
            anm.SetBool("isHurting", true);
            anm.SetBool("isMeele", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders"))
        {
            isLadder = false;
            isClimbing = false;
            Debug.Log("isladder false");
        }
      

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isFloor = true;
        }
     
        if (collision.gameObject.tag == "Axe")
        {
            isDead = true;
            Destroy(gameObject, 0.7f);
            SceneManager.LoadScene("GameOver");
            anm.SetTrigger("dead");
        }
        if (collision.gameObject.tag == "Spike")
        {
            isDead = true;
            Destroy(gameObject, 0.7f);
            SceneManager.LoadScene("GameOver");
            anm.SetTrigger("dead");
        }
        if (collision.gameObject.tag == "Enemy1")
        {
            rb.AddForce(new Vector2(shovedir, 10));
            anm.SetBool("isWalking", false);
            anm.SetBool("isJumping", false);
            anm.SetBool("isClaimbing", false);
            anm.SetBool("isHurting", true);
            anm.SetBool("isMeele", false);
            life--; 
        }

 
    }
}
