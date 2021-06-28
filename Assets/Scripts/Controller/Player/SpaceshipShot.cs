using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShot : MonoBehaviour
{
    public float speed = 5;
    public float lifetime = 3;


    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
