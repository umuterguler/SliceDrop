using Assets.Scripts.Data.Enums;
using Assets.Scripts.Data.Models;
using Assets.Scripts.General;
using Assets.XAssets.UIFinalPanelSystem.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static StarsController;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    private PlayerPrefsManager playerPrefsManager;
    private UIMain UI_Main;
    private LevelStatusEnum levelStatus = LevelStatusEnum.Ready;

    [SerializeField] public GameObject[] LevelList;
    [SerializeField] public GameObject[] ScampList;
    [SerializeField] public GameObject LevelParent;
    [SerializeField] public GameObject ScampParent;

    [SerializeField] public GameObject Roll;
    [SerializeField] public GameObject BallParent;

    [SerializeField] private string[] SlogansGood;
    [SerializeField] private string[] SlogansBad;



    [HideInInspector] public int rightSliceCount = 0;
    [HideInInspector] public int sliceCount;
    [HideInInspector] public int ballCount;
    [HideInInspector] public string text;




    private void Update()
    {
        if (levelStatus == LevelStatusEnum.Continues)
        {
            
            CheckScore();
        }
    }
    private void Awake()
    {
        sliceCount = Roll.transform.GetChild(0).GetChild(1).childCount;
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
        UI_Main = FindObjectOfType<UIMain>();
        InstantiateNewLevel();
    }

    public void FinishLevel()
    {
        
        print("finishLevel");

    }

    public void SetLevelStatus(LevelStatusEnum levelStatusEnum)
    {
        levelStatus = levelStatusEnum;
    }

    public LevelStatusEnum GetLevelStatus()
    {
        return levelStatus;
    }

    public void CheckScore()
    {
        if (rightSliceCount < 0)
        {
            rightSliceCount = 0;
        }
    }
    

    public void LevelFinish()
    {
        if (sliceCount == ballCount+1)
        {
            this.Wait(2f, () =>
            {
                if (IsWin())
                {
                    LevelWin();
                }
                else
                {
                    LevelFail();
                }
            }
            );
        }
    }

    public void LevelWin()
    {
        PanelFinalModel panelFinalModel = new PanelFinalModel(true, rightSliceCount);
        SetLevelStatus(LevelStatusEnum.Win);
        UI_Main.ShowPanelFinal(panelFinalModel);
    }

    public void LevelFail()
    {
        PanelFinalModel panelFinalModel = new PanelFinalModel(false, rightSliceCount);
        SetLevelStatus(LevelStatusEnum.Fail);
        UI_Main.ShowPanelFinal(panelFinalModel);
    }

    public bool IsWin()
    {
        if (rightSliceCount < CalculateStarPercent(20))
        {
            // Fail
            return false;
        }
        else
        {
            //Win
            return true;
        }
    }

    public float CalculateStarPercent(int percent)
    {
        float newPercent = sliceCount * percent / 100;
        return newPercent;
    }

    public StarsEnum CalculateStars()
    {
        if (rightSliceCount >= sliceCount * 80 / 100)
        {
            return StarsEnum.ThreeStar;
        }
        else if (rightSliceCount >= sliceCount * 50 / 100)
        {
            return StarsEnum.TwoStar;
        }
        else if (rightSliceCount >= sliceCount * 20 / 100)
        {
            return StarsEnum.OneStar;
        }
        else if (rightSliceCount < sliceCount * 20 / 100)
        {
            return StarsEnum.ZeroStar;
        }
        return StarsEnum.ZeroStar;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(0);
        levelStatus = LevelStatusEnum.Ready;
        playerPrefsManager.NextLevel();
    }

    public void TryAgain()
    {   
        levelStatus = LevelStatusEnum.Ready;
        SceneManager.LoadScene(0);
    }

    public void InstantiateNewLevel()
    {
        if (playerPrefsManager.GetCurrentLevel() > 0)
        {
            Destroy(LevelParent.transform.GetChild(0).gameObject);
            Destroy(ScampParent.transform.GetChild(0).gameObject);

            this.Wait(0.01f, () =>
            {
                Instantiate(LevelList[playerPrefsManager.GetCurrentLevel()], LevelParent.transform);
                Instantiate(ScampList[playerPrefsManager.GetCurrentLevel()], ScampParent.transform);
            });

        }
    }



    public string RandomSloganGood()
    {
        int rnd = Random.Range(0, SlogansGood.Length);
        return SlogansGood[rnd];
    }

    public string RandomSloganBad()
    {
        int rnd = Random.Range(0, SlogansBad.Length);
        return SlogansBad[rnd];
    }


    private float CalculateOneItemValue()
    {
        float oneItemValue = 0;
        oneItemValue = (float)100 / sliceCount;
        return rightSliceCount * oneItemValue;
    }


    public void SliceRightAdd()
    {
        rightSliceCount += 1;
        UI_Main.SliderFill(CalculateOneItemValue(), rightSliceCount);
    }







}
