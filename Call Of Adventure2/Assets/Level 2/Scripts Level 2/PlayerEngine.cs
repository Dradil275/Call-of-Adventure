using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerEngine : MonoBehaviour
{
    float x;
    float speed;
    float T;
    float jumpHight;
    public int life;
    int oldlife;
    public GameObject ladders;
    public bool climb;
    bool isFloor;
    private float vertical;
    private float climbspeed = 5f;
    private bool isLadder;
    private bool isClimbing;

    Animator anm;

    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        life = 3;
        climb = false;
        isFloor = true;
        anm = GetComponent<Animator>();
        jumpHight = 300f;
    }

    // Update is called once per frame
    void Update()
    {

        //Movement
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(x, 0, 0);
        

        if (x == 0 && isFloor)
        {
            anm.SetBool("isWalk", false);
            anm.SetBool("isJump", false);
            anm.SetBool("isClimb", false);
            anm.SetBool("isHurt", false);
            anm.SetBool("isAtk", false);


        }

        // facing
        if (x > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);

        }


        if (x < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);

        }
        //walking
        if (x < 0 && isFloor == true && isClimbing == false)
        {
            anm.SetBool("isWalk", true);
            anm.SetBool("isJump", false);
            anm.SetBool("isClimb", false);
            anm.SetBool("isHurt", false);
            anm.SetBool("isAtk", false);
        }
        if (x > 0 && isFloor == true && isClimbing == false)
        {
            anm.SetBool("isWalk", true);
            anm.SetBool("isJump", false);
            anm.SetBool("isClimb", false);
            anm.SetBool("isHurt", false);
            anm.SetBool("isAtk", false);
        }
        //jump
        if (Input.GetKeyDown(KeyCode.W) && isFloor == true)
        {
            rb.AddForce(new Vector2(0, jumpHight));
            anm.SetBool("isWalk", false);
            anm.SetBool("isJump", true);
            anm.SetBool("isClimb", false);
            anm.SetBool("isHurt", false);
            anm.SetBool("isAtk", false);
            isFloor = false;

        }
        //small tab on W make it jump less
        if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        //ladder code
        vertical = Input.GetAxis("Vertical");
        if (isLadder == true && Mathf.Abs(vertical) > 0)
        {
            anm.SetBool("isWalk", false);
            anm.SetBool("isJump", false);
            anm.SetBool("isClimb", true);
            anm.SetBool("isHurt", false);
            anm.SetBool("isAtk", false);
            isClimbing = true;
        }
        //airtime
        if (isFloor == false && isClimbing == false)
        {
            anm.SetBool("isWalk", false);
            anm.SetBool("isJump", true);
            anm.SetBool("isClimb", false);
            anm.SetBool("isHurt", false);
            anm.SetBool("isAtk", false);
        }
        //Attack
        if (Input.GetKeyDown(KeyCode.F))
        {
            anm.SetBool("isWalk", false);
            anm.SetBool("isJump", false);
            anm.SetBool("isClimb", false);
            anm.SetBool("isHurt", false);
            anm.SetBool("isAtk", true);
        }
        // if hurt
        if (life < oldlife)
        {
            Debug.Log("Hurt");

            anm.SetBool("isWalk", false);
            anm.SetBool("isJump", false);
            anm.SetBool("isClimb", false);
            anm.SetBool("isHurt", true);
            anm.SetBool("isAtk", false);
            Pause(0.04f);

        }
        //max life
        if (life > 10)
        {
            life = 10;
        }
        // death condition
        if (life == 0)
        {
            anm.SetBool("isWalk", false);
            anm.SetBool("isJump", false);
            anm.SetBool("isClimb", false);
            anm.SetBool("isHurt", false);
            anm.SetBool("isAtk", false);
            anm.SetTrigger("Dead");
            SceneManager.LoadScene("GameOver2");
            Destroy(gameObject, 0.6f);
            

        }
        //on next frame old life will represent last frames life
        oldlife = life;

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
    // enter and exit ladder
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladders"))
        {
            isLadder = true;
            
        }
        if (collision.CompareTag("Speed"))
        {
            speed = 8f;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Jump"))
        {
            jumpHight = 380f;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Life") && life < 10)
        {
            life++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("BossSword"))
        {
            life--;
        }
        if(collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Victory");
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
    //collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isFloor = true;

        }
        if (collision.gameObject.tag == "Border")
        {
            life = 0;
        }
        if(collision.gameObject.tag == "Acid")
        {
            life = 0;
        }
    }
    //pause function
    IEnumerator Pause(float T)
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(T);
        print(Time.time);
    }
    

}
