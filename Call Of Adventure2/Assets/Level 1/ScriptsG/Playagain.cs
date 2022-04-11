using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Playagain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void PlayAgain(string name)
    {
        if (name == "PLAYAGAIN")
        {
            SceneManager.LoadScene("SideScrolling 0");
        }
    }
   
}
