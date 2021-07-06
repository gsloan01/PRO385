using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get { return instance; } }
    static GameController instance;

    //how fast the roads move
    public float gameSpeed = 5;
    //how long between spawns
    public float timeBetweenSpawn = 1;
    //score
    public float points = 0;

    /// <summary>
    /// 0 - Main
    /// 1 - Game
    /// 2 - Pause
    /// 3 - Loss
    /// </summary>
    public List<AudioClip> music = new List<AudioClip>();
    public Transform nextBlockSpawn;
    public GameObject Player;


    float pointMultiplier = 1;
    float currentRunTime = 0;

    float timer = 0;


    public enum gameState
    {
        Menu, Game, Pause, Loss
    }

    public gameState state = gameState.Menu;
    

    public List<GameObject> roadSections = new List<GameObject>();

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

                timer += Time.deltaTime;
                if (timer >= timeBetweenSpawn)
                {
                    CreateBlock();
                    timer = 0;
                }
                //If the game is out of the beginning
                if (currentRunTime >= 5)
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
        //Debug.Log("Creating block");
        GameObject temp = Instantiate(roadSections[Random.Range(0, roadSections.Count)], nextBlockSpawn.position, Quaternion.identity);
        //Debug.Log("Created " +temp.name);
        nextBlockSpawn = temp.transform.GetChild(0).transform;
        //Debug.Log("Next spawn " + nextBlockSpawn.ToString());


        
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
