using Assets.XAssets.UIFinalPanelSystem.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelFinal : MonoBehaviour
{
    public static UIPanelFinal Instance;

    public Text TextTitle;
    public Text CollectedBallCount;

    [Header("PanelContent")]
    public GameObject PanelContent;

    [Header("PanelWin")]
    public GameObject PanelWin;

    [Header("PanelLose")]
    public GameObject PanelLose;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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



    /// <summary>
    /// TopPanel'e eklenen Slider'ı set eder. 
    /// </summary>
    /// <param name="countNumber">Slider'a set edilecek değer. 0-100</param>
    public void SliderFill(int countNumber)
    {
       // MainSliderController.Instance.SliderFill(countNumber);
    }


    public void SetPanelFinal(PanelFinalModel panelFinalModel)
    {
        if (panelFinalModel.FinalStatus == true)
        {
            ShowPanelWin();
        }
        else
        {
            ShowPanelLose();
        }

        CollectedBallCount.text = "Succeed Slice " + panelFinalModel.CollectedBallCount;
        StarsController.Instance.SetStars(ScoreManager.Instance.CalculateStars());
    }



    private void ShowPanelWin()
    {
        PanelWin.SetActive(true);
        TextTitle.text = "Level Completed";
    }

    private void ShowPanelLose()
    {        
        PanelLose.SetActive(true);
        TextTitle.text = "Level Failed";
        StarsController.Instance.SetStars(StarsController.StarsEnum.TwoStar);
    }      
    

    /// <summary>
    /// Level sonu yıldız animasyonunu set eder. 
    /// </summary>
    /// <param name="starsEnum">Kaç yılız açacağını Enum parametresi ile belirlersin.</param>
    public void SetFinalStars(StarsController.StarsEnum starsEnum)
    {
        StarsController.Instance.SetStars(starsEnum);
    }




}
