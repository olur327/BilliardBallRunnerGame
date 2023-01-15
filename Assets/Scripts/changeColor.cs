using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    public Material[] materials;
    MeshRenderer mesh;
    int i = 0;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material = materials[i];
    }
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball") && collision.gameObject.GetComponent<MeshRenderer>().material.ToString() == mesh.material.ToString())
        {
            Destroy(collision.gameObject);
            mesh.material = materials[i + 1];
            i++;
        }
        
        
    }
}
