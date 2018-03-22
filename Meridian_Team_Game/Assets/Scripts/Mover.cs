using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry2
{
    public float yMin, yMax;
}

public class Mover : MonoBehaviour
{
    private Rigidbody rb;

    public Boundry2 boundry; 
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
    void Update() {
        rb.position = new Vector3(rb.position.x, 0.5f, rb.position.z);
    
    }
}
