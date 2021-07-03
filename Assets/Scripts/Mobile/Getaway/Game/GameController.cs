using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get { return instance; } }
    static GameController instance;

    public Transform newBlockLocator;

    //determines how many obstacle blocks there are before there is a clear one
    public int blocksBetweenBreaks = 5;
    int safetyCountdown = 0;

    public float points = 0;
    public float pointMultiplier = 1;
    public float currentRunTime = 0;

    public enum gameState
    {
        Menu, Game, Pause, Loss
    }

    public gameState state = gameState.Menu;

    //these lists hold all of the possible blocks that could spawn in the game
    public List<Block> obstacleBlocks = new List<Block>();
    public List<Block> safeBlocks = new List<Block>();

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        switch (state)
        {
            case gameState.Menu:
                currentRunTime = 0;
                break;
            case gameState.Game:
                currentRunTime += Time.deltaTime;
                //If the game is out of the beginning
                if(currentRunTime >= 5)
                {
                    //Add points as time goes on
                    points += Time.deltaTime * pointMultiplier;
                }
                break;
            case gameState.Pause:
                break;
            case gameState.Loss:
                //if current run time is the longest, set it as new record
                //show loss menu and offer retry
                break;
            default:
                break;
        }
    }

    public void CreateBlock()
    {
        //if there have been 5 obstacle blocks in a row
        if(safetyCountdown == 0)
        {
            //spawn a new block that is a random safe one
            Instantiate(safeBlocks[Random.Range(0, safeBlocks.Count)], null, true);
            safetyCountdown = blocksBetweenBreaks;
        }
        else
        {
            Instantiate(obstacleBlocks[Random.Range(0, safeBlocks.Count)], null, true);
            safetyCountdown--;
        }
        
    }
}
