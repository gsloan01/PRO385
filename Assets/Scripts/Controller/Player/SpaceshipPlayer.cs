using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipPlayer : MonoBehaviour
{
    //movement speed
    public float speed = 2;

    //player shot
    public GameObject shot;

    //input value
    Vector2 input;

    void Start()
    {
        
    }

    void Update()
    {
        //Movement
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        transform.Translate(input * speed * Time.deltaTime);

        if(Input.GetButtonDown("Fire1"))
        {
            OnFire();
        }
    }

    void OnFire()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }
}
