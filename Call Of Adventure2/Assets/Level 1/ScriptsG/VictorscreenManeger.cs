using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictorscreenManeger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Playagain(string name)
    {
        if(name == "PLAYONE")
        {
            SceneManager.LoadScene("SideScrolling 0");
        }
        if(name == "PLAYTWO")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
