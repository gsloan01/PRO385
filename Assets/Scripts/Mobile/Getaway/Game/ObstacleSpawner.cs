using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles;

    public float minTimeBetween = 2.0f;
    float timer = 0;

    private void Update()
    {
        if(GameController.Instance.state == GameController.gameState.Game)
        {
            timer += Time.deltaTime;
            if (timer >= (minTimeBetween + Random.Range(0, 2)))
            {
                Instantiate(obstacles[Random.Range(0, obstacles.Count)], transform.position, Quaternion.identity);
                timer = 0;
            }
        }

    }
}
