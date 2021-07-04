using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get { return instance; } }
    static GameController instance;
    /// <summary>
    /// 0 - Main
    /// 1 - Game
    /// 2 - Pause
    /// 3 - Loss
    /// </summary>
    public List<AudioClip> music = new List<AudioClip>();
    public Vector3 nextBlockSpawn;

    public GameObject Player;

    //determines how many obstacle blocks there are before there is a clear one
    public int blocksBetweenBreaks = 5;
    int safetyCountdown = 0;

    public float points = 0;
    float pointMultiplier = 1;
    float currentRunTime = 0;


    public enum gameState
    {
        Menu, Game, Pause, Loss
    }

    public gameState state = gameState.Menu;
    
    //these lists hold all of the possible blocks that could spawn in the game
    public List<GameObject> obstacleBlocks = new List<GameObject>();
    public List<GameObject> safeBlocks = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (instance == null) instance = this;
        CreateBlock();
        CreateBlock();
        CreateBlock();
        CreateBlock();
        CreateBlock();
        CreateBlock();
        CreateBlock();
        CreateBlock();
        CreateBlock();
        CreateBlock();
        CreateBlock();
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
                //set timescale to 0
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
            GameObject temp = Instantiate(safeBlocks[Random.Range(0, safeBlocks.Count)], nextBlockSpawn, Quaternion.identity);
            nextBlockSpawn = temp.transform.GetChild(0).position;
            safetyCountdown = blocksBetweenBreaks;
        }
        else
        {
            GameObject temp = Instantiate(safeBlocks[Random.Range(0, obstacleBlocks.Count)], nextBlockSpawn, Quaternion.identity);
            nextBlockSpawn = temp.transform.GetChild(0).position;
            safetyCountdown--;
        }
        
    }

    public void OnMenu()
    {
        GetComponent<AudioSource>().clip = music[0];
    }
    public void OnGame()
    {
        GetComponent<AudioSource>().clip = music[1];
    }
    public void OnLoss()
    {
        GetComponent<AudioSource>().clip = music[3];
    }
    public void OnPause()
    {
        GetComponent<AudioSource>().clip = music[2];
    }
}
