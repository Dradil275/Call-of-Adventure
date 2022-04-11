using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManegerLVL1 : MonoBehaviour
{
   public bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameover == true)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
