using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{


    /// <summary>
    /// Speed at which the roads will travel towards the player, simulating movement
    /// </summary>



    void Update()
    {
        //Move the Block Towards the player
        //Moves it backwards, held back by time and altered by gameSpeed
        if(GameController.Instance.state == GameController.gameState.Game)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * GameController.Instance.gameSpeed);
        }

        
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    //once the player leaves the zone of the block, destroy the block
    //    if(other.transform.CompareTag("Player"))
    //    {
    //        GameController.Instance.CreateBlock();
    //        Destroy(gameObject);
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    //once the player leaves the zone of the block, destroy the block
    //    if (collision.transform.CompareTag("Player"))
    //    {
    //        GameController.Instance.CreateBlock();
    //        Destroy(gameObject);
    //    }
    //}
}
