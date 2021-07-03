using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    /// <summary>
    /// Section of the block that is the first to be deleted
    /// </summary>
    public GameObject head;
    /// <summary>
    /// End of the block, last deleted
    /// </summary>
    public GameObject tail;

    /// <summary>
    /// Speed at which the roads will travel towards the player, simulating movement
    /// </summary>
    public float gameSpeed = 5.0f;


    void Update()
    {
        //Move the Block Towards the player
        //Moves it backwards, held back by time and altered by gameSpeed
        transform.Translate(-Vector3.forward * Time.deltaTime * gameSpeed);

        //if the tail has been destroyed, destroy the whole block after half a second
        if(tail == null)
        {
            Destroy(this, 0.5f);
        }
    }
}
