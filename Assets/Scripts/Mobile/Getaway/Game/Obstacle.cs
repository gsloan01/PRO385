using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    void Update()
    {
        if (GameController.Instance.state == GameController.gameState.Game)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * GameController.Instance.gameSpeed);
        }
    }
}
