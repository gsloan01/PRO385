using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "DontDelete" && other.tag != "Player")
        {
            Destroy(other.gameObject);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "DontDelete" && collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
