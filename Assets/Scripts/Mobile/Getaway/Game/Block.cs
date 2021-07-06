using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{




    void Update()
    {
        //Move the Block Towards the player
        //Moves it backwards, held back by time and altered by gameSpeed
        if(GameController.Instance.state == GameController.gameState.Game)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * GameController.Instance.gameSpeed);
        }

        
    }


}
