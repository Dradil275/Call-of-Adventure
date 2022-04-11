using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCreate : MonoBehaviour
{
    public GameObject Health;

    Vector2 pos1;
    Vector2 pos2;
    Vector2 pos3;
    Vector2 pos4;
    Vector2 pos5;
    Vector2 pos6;
    Vector2 pos7;
    Vector2 pos8;
    Vector2 pos9;
    Vector2 pos10;
    Vector2 pos11;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = new Vector2(-1.28f , -15.75f );
        pos2 = new Vector2(2.31f,-15.75f );
        pos3 = new Vector2(47.42f,-2.85f );
        pos4 = new Vector2(73.25f,-26.8f);
        pos5 = new Vector2(105.5f,-26.8f);
        pos6 = new Vector2(129.2f,-26.8f);
        pos7 = new Vector2(173, -31.8f);
        pos8 = new Vector2(201.8f, -30.6f);
        pos9 = new Vector2(206, -30.6f);
        pos10 = new Vector2(210, -30.6f);
        pos11 = new Vector2(214, -30.6f);


        Instantiate(Health, pos1, Health.transform.rotation);
        Instantiate(Health, pos2, Health.transform.rotation);
        Instantiate(Health, pos3, Health.transform.rotation);
        Instantiate(Health, pos4, Health.transform.rotation);
        Instantiate(Health, pos5, Health.transform.rotation);
        Instantiate(Health, pos6, Health.transform.rotation);
        Instantiate(Health, pos7, Health.transform.rotation);
        Instantiate(Health, pos8, Health.transform.rotation);
        Instantiate(Health, pos9, Health.transform.rotation);
        Instantiate(Health, pos10, Health.transform.rotation);
        Instantiate(Health, pos11, Health.transform.rotation);
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
