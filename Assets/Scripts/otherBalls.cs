using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherBalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LimitX();
    }
    void LimitX()
    {
        if (transform.position.x <= -4f)
        {
            transform.position = new Vector3(-4f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 4f)
        {
            transform.position = new Vector3(4f, transform.position.y, transform.position.z);
        }
    }
}
