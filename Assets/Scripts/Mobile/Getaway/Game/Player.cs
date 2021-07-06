using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //LeftRightSpeed
    public Transform leftBound;
    public Transform RightBound;
    Rigidbody rb;
    
    //Set animation triggers

    //Controls

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mathf.Clamp(rb.position.x, leftBound.position.x, RightBound.position.x);
    }
}
