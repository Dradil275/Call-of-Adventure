using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMgcEngine : MonoBehaviour
{
    GameObject playerC;
    public GameObject player;
    float MgctXatshot;
    float playerXatshot;
    bool activateXatshot;
    Animator anm;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        activateXatshot = true;
        anm = GetComponent<Animator>();
        playerC = GameObject.Find("Player");
        playerXatshot = player.transform.position.x;
        MgctXatshot = gameObject.transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        if (playerXatshot < MgctXatshot)
        {
            rb.AddForce(new Vector2(-200, 0));
        }
        if (playerXatshot > MgctXatshot)
        {
            rb.AddForce(new Vector2(200, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Ground")
        {
            anm.SetTrigger("Explosion");
            Destroy(gameObject, 0.6f);
        }
        if(collision.gameObject.tag == "Player")
        {
            playerC.GetComponent<PlayerEngine>().life--;
        }
    }
}
