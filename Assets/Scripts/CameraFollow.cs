using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float speed, offSet;
    Vector3 finalPos;
    public bool canFollow;
    public movement mv;

    void Start()
    {
        finalPos = new Vector3(0, 7f, -15f);
    }
    void Update()
    {     
        if(mv.rb.velocity.z > 1)
        {
            canFollow = true;
        }
        if(Time.timeScale != 0 && !canFollow) 
        {
            transform.position = Vector3.Slerp(transform.position, finalPos, 0.12f);
        }
        if (canFollow)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, target.position.z - offSet);
            transform.position = Vector3.Slerp(transform.position, pos, speed);
        }
    }
}
