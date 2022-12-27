using Assets.Scripts.Data.Enums;
using Assets.Scripts.General;
using Assets.XAssets.UIFinalPanelSystem.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    private PlayerAnimation playerAnimation = new PlayerAnimation();

    public GameObject PanelFinal;
    public GameObject PanelStart;
    public GameObject PanelTop;
    public GameObject Knife;

    [SerializeField] private Text Level;
    [SerializeField] private Text Score;

    private PlayerPrefsManager playerPrefsManager;

    void Start()
    {
        playerAnimation.Init(Knife.transform.GetComponent<Animator>());
        playerPrefsManager = new PlayerPrefsManager();
        MainSliderController.Instance.SetStarsLimit(Constant.Star1Limit, Constant.Star2Limit, Constant.Star3Limit);

    }

    void Update()
    {
        if (ScoreManager.Instance.GetLevelStatus() == LevelStatusEnum.Continues || ScoreManager.Instance.GetLevelStatus() == LevelStatusEnum.Ready)
        {
            PrintTopPanel();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (ScoreManager.Instance.GetLevelStatus() == LevelStatusEnum.Ready)
            {
                ScoreManager.Instance.SetLevelStatus(LevelStatusEnum.Continues);
                PanelStart.SetActive(false);
                playerAnimation.SetActionStatus(PlayerAnimationEnum.Idle);
            }
        }
    }

    private void PrintTopPanel()
    {
        Level.text = "Level: " + (playerPrefsManager.GetCurrentLevel() + 1).ToString();
        Score.text = "Score: " + ScoreManager.Instance.rightSliceCount.ToString();
    }

    public void ShowPanelFinal(PanelFinalModel panelFinalModel)
    {
        PanelTop.SetActive(false);
        PanelFinal.SetActive(true);

        UIPanelFinal.Instance.SetPanelFinal(panelFinalModel);

    }



    public void SliderFill(float countedSlider, int countedText)
    {
        MainSliderController.Instance.SliderFill(countedSlider, countedText);
    }




}
