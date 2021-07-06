using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get { return instance; } }
    static GameController instance;

    public MenuController menuController;
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
    public Transform leftSpawn;
    public Transform rightSpawn;
    public GameObject Player;

    public int numToSpawn = 10;

    float pointMultiplier = 1;
    float currentRunTime = 0;
    bool paused = false;
    float timer = 0;


    public enum gameState
    {
        Menu, Game, Pause, Loss
    }

    public gameState state = gameState.Menu;
    

    public List<GameObject> roadSections = new List<GameObject>();
    public List<GameObject> leftBuildings = new List<GameObject>();
    public List<GameObject> rightBuildings = new List<GameObject>();


    private void Awake()
    {
        instance = this;
        menuController = GetComponent<MenuController>();
    }
    private void Start()
    {
        if (instance == null) instance = this;
        for (int i = 0; i < numToSpawn; i++)
        {
            CreateBlock();
            //CreateBuildings();
        }
        
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
                    //CreateBuildings();
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
    public void CreateBuildings()
    {
        GameObject left = Instantiate(leftBuildings[Random.Range(0, leftBuildings.Count)], leftSpawn.position, Quaternion.identity);
        GameObject right = Instantiate(rightBuildings[Random.Range(0, rightBuildings.Count)], rightSpawn.position, Quaternion.identity);
        //Debug.Log("Created " +temp.name);
        leftSpawn = left.transform.GetChild(0).transform;
        //Debug.Log("Created " +temp.name);
        rightSpawn = right.transform.GetChild(0).transform;
    }

    public void OnMenu()
    {
        GetComponent<AudioSource>().clip = music[0];
        state = gameState.Menu;
        Player.SetActive(false);
        Time.timeScale = 1;
        GetComponent<MenuController>().cam.SetActive(true);
        
    }
    public void OnGame()
    {
        GetComponent<AudioSource>().clip = music[1];
        state = gameState.Game;
        Player.SetActive(true);
        Time.timeScale = 1;
    }
    public void OnLoss()
    {
        //GetComponent<AudioSource>().clip = music[3];
        state = gameState.Loss;
        Time.timeScale = 1;
    }
    public void OnPause()
    {
        if(paused)
        {
            GetComponent<AudioSource>().clip = music[2];
            state = gameState.Pause;
            Time.timeScale = 0;
        }
        else
        {
            OnGame();
        }

    }

    

    public void StartGame_OnClick()
    {
        Camera.main.GetComponent<Animator>().SetTrigger("GameStart");
        
    }
}
