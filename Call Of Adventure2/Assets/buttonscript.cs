using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(string name)
    {
        if(name == "START")
        {
            SceneManager.LoadScene("SideScrolling 0");
        }
        if(name == "CONTROLS")
        {
            SceneManager.LoadScene("Controls");

        }
        if(name == "MAIN")
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
