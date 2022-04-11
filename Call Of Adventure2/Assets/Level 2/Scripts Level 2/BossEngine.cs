using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossEngine : MonoBehaviour
{
    float distanceFromPlayer;
    float maxdistancefromPlayer;
    float startBossX;
    float BossX;
    float attackRange;
    float BossSpeed;
    float wheremgc;
    float playerX;
    float BossattackRange;
    int BossLife;
    public Transform PlayerTrm;
    float RNG;
    Animator anm;
    public GameObject BossMagic;
    bool isAtk;
    public GameObject victorygate;
    bool isWinPortal;
    // Start is called before the first frame update
    void Start()
    {
        isWinPortal = false;
        attackRange = 1;
        BossLife = 5;
        BossSpeed = 1.5f;
        startBossX = gameObject.transform.position.x;
        maxdistancefromPlayer = 4f;
        anm = GetComponent<Animator>();
        isAtk = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // movement
        distanceFromPlayer = Vector2.Distance(PlayerTrm.position, gameObject.transform.position);
        playerX = PlayerTrm.position.x;
        BossX = gameObject.transform.position.x;

        if(maxdistancefromPlayer > distanceFromPlayer && isAtk == false)
        {
            Debug.Log("boss move");
            transform.position = Vector3.MoveTowards(this.transform.position, PlayerTrm.position, BossSpeed * Time.deltaTime);
            maxdistancefromPlayer = 20f;
            anm.SetBool("isBossAtk", false);
            anm.SetBool("isBossMgc", false);
            anm.SetBool("isBossWalk", true);

        }
        // facing
        if (playerX < BossX)
        {
            gameObject.transform.localScale = new Vector2(-1.753369f, gameObject.transform.localScale.y);
            wheremgc = -1;
        }
        if (playerX > BossX)
        {
            gameObject.transform.localScale = new Vector2(1.753369f, gameObject.transform.localScale.y);
            wheremgc = 1;
        }
        // when to attack
        if (distanceFromPlayer < attackRange)
        {
            
            isAtk = true;
            AttackSword(); 
        }
        if (distanceFromPlayer > attackRange)
        {
            
            isAtk = false;
            anm.SetBool("isBossAtk", false);
            anm.SetBool("isBossMgc", false);
            anm.SetBool("isBossWalk", true);
        }
            // when release shot
            RNG = Random.Range(1 , 1000);
        
        if (RNG > 990 && isAtk == false)
        {
          
            AttackMgc();
        }
        //death condition
        
        if(BossLife == 0 && isWinPortal == false)
        {
            anm.SetTrigger("isBossDead");
            Instantiate(victorygate, new Vector3(gameObject.transform.position.x + wheremgc + 4, gameObject.transform.position.y - 0.8f, gameObject.transform.position.z), gameObject.transform.rotation);
            Destroy(gameObject, 0.4f);
            isWinPortal = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Sword"))
        {
            BossLife--;
        }
       
    }
    public void AttackSword()
    {
        isAtk = true;     
            anm.SetBool("isBossAtk", true);
            anm.SetBool("isBossMgc", false);
            anm.SetBool("isBossWalk", false);
    }
    public void AttackMgc()
    {
        anm.SetBool("isBossAtk", false);
        anm.SetBool("isBossMgc", true);
        anm.SetBool("isBossWalk", false);
        Instantiate(BossMagic, new Vector3(gameObject.transform.position.x + wheremgc, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
    }
    
}
