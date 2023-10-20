using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     public static GameManager singleton;

    private GroundPiece[] allGroundPieces;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetupNextLevel()
    {
        allGroundPieces = FindObjectsOfType<GroundPiece>();
    }

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }else if(singleton != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        SetupNextLevel();
    }
    public void CheckComplete()
    {
        bool isFinished = true;

        for (int i = 0; i < allGroundPieces.Length; i++)
        {
            if(allGroundPieces[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }
        if (isFinished)
        {
            //Next Level
            Nextlevel();

        }
    }
    private void Nextlevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       
    }
     
}
