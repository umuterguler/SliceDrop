using Assets.Scripts.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance { get; private set; }
    private PlayerPrefsManager playerPrefsManager;



    private void Awake()
    {
        Application.targetFrameRate = 60;      

        if (Instance == null)
        {
            Instance = this;
            playerPrefsManager = new PlayerPrefsManager();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }





    public string GetCurrentLevel()
    {
        int currentLevelIndex = playerPrefsManager.GetCurrentLevel();
        return "Level " + (currentLevelIndex + 1).ToString();
    }





}
