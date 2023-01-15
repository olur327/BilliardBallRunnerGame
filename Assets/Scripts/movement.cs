using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;
    [SerializeField]
    float speed;
    Vector3 firstPos,lastPos;
    public bool canMove;
    public bool endGame;
    public bool isWin;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        forwardMovement();
        HoldMove();   
        LimitX();
    }

    void forwardMovement()
    {
        if (canMove && rb.velocity.z < speed)
        { rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed); }
    }

    void HoldMove()
    {
        
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPos = Input.mousePosition;
                lastPos = firstPos;
            }
            if (Input.GetMouseButton(0))
            {
                lastPos = Input.mousePosition;
                rb.velocity = new Vector3((float)(lastPos.x - firstPos.x) * Time.deltaTime * 2f, rb.velocity.y, rb.velocity.z);
            }

            if (Input.GetMouseButtonUp(0))
            {
                firstPos = Vector3.zero;
                lastPos = Vector3.zero;
                rb.velocity = new Vector3((float)(lastPos.x - firstPos.x) * Time.deltaTime * 2f, rb.velocity.y, rb.velocity.z);
            }
        }
    }

    void LimitX()
    {
        if(transform.position.x <= -4f)
        {
            transform.position = new Vector3(-4f,transform.position.y,transform.position.z);
        }
        else if(transform.position.x >= 4f) 
        {
            transform.position = new Vector3(4f, transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "cue")
        {
            canMove = true;
        }
        if (collision.gameObject.CompareTag("block"))
        {
            rb.isKinematic = true;
            canMove = false;
            endGame = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("finish")){
            isWin = true;
            canMove = false;
        }
    }

}
