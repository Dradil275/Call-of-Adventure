using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Healthscript : MonoBehaviour
{

    GameObject Player;
    int health;
    public int HeartCounter;
    [SerializeField] private Image Hearts;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        
       
    }

    // Update is called once per frame
    void Update()
    {
        HeartCounter = Player.GetComponent<Player1Engine>().life;
       if(HeartCounter == 1)
        {
            Hearts.fillAmount = 0.1f;
        }
        if (HeartCounter == 2)
        {
            Hearts.fillAmount = 0.2f;
        }
        if (HeartCounter == 3)
        {
            Hearts.fillAmount = 0.3f;
        }
        if (HeartCounter == 4)
        {
            Hearts.fillAmount = 0.4f;
        }
        if (HeartCounter == 5)
        {
            Hearts.fillAmount = 0.5f;
        }
        if (HeartCounter == 6)
        {
            Hearts.fillAmount = 0.6f;
        }
        if (HeartCounter == 7)
        {
            Hearts.fillAmount = 0.7f;
        }
        if (HeartCounter == 8)
        {
            Hearts.fillAmount = 0.8f;
        }
        if (HeartCounter == 9)
        {
            Hearts.fillAmount = 0.9f;
        }
        if (HeartCounter == 10)
        {
            Hearts.fillAmount = 1f;
        }
    }

}
