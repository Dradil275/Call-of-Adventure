using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Playertrm;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(Playertrm.position.x, Playertrm.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Playertrm.position.x, Playertrm.position.y, -10);
    }
}
