using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cue : MonoBehaviour
{
    Rigidbody rb;
    bool goBack = true;
    Vector3 firstPos;
    public CameraFollow cameraFollow;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firstPos = transform.position;
        
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        forced();
    }

    void forced()
    {
        if (goBack)
        {
            if(firstPos.z - transform.position.z < 5)
            {
                rb.velocity = (Vector3.back * 5f);
            }
            else
            {
                goBack = false;
            }

        }
        else
        {
            rb.velocity = Vector3.forward * 80f;
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.isKinematic= true;
        }
    }
}
