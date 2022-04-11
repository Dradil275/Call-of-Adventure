﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAtackkColEngine : MonoBehaviour
{
    GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hitplayer");
        player.GetComponent<PlayerEngine>().life--;

        }
    }
}
