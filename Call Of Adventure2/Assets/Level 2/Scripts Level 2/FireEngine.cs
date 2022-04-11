using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEngine : MonoBehaviour
{
    GameObject playerC;
    public GameObject Player;
    float shotXatshot;
    float playerXatshot;
    bool activateXatshot;
    Animator anm;
    bool isHit;
    // Start is called before the first frame update
    void Awake()
    {
        activateXatshot = true;
        anm = GetComponent<Animator>();
        isHit = false;
        playerC = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (activateXatshot == true)
        {
            Xatshot();
            activateXatshot = false;
        }
       
       
        
        if (shotXatshot > playerXatshot && isHit == false)
        {
            
            transform.Translate(-0.05f, 0, 0);
        }
        if (shotXatshot < playerXatshot && isHit == false)
        {
            
            transform.Translate(0.05f, 0, 0);
        }

    }



    public void Xatshot()
    {
        shotXatshot = gameObject.transform.position.x;
        playerXatshot = Player.transform.position.x;
 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            playerC.GetComponent<PlayerEngine>().life --;
            isHit = true;
            anm.SetTrigger("ifPlayer");
            Destroy(gameObject, 1f);
            
        }
        if(collision.gameObject.tag == "Ground")
        {
            anm.SetTrigger("ifPlayer");
            Destroy(gameObject, 1f);
        }
        
    }

}
