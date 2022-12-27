using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSliderController : MonoBehaviour
{
    public static MainSliderController Instance;
    public Image[] smallStars;
    public Slider MainSlider;
    public Text TextCount;


    private bool star1Done, star2Done, star3Done;
    private int Star1Limit;//30
    private int Star2Limit;//60
    private int Star3Limit;//80


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
        if (Star1Limit == 0 || Star2Limit == 0 || Star3Limit == 0)
        {
            //Debug.LogError("Star1Limit - Star2Limit - Star3Limit variables are not assigned through the editor... (MainSliderController)");
            //UnityEditor.EditorApplication.isPlaying = false;
        }


    }

    void Update()
    {
        
    }


    public void SetStarsLimit(int star1Limit, int star2Limit, int star3Limit)
    {
        this.Star1Limit = star1Limit;
        this.Star2Limit = star2Limit;
        this.Star3Limit = star3Limit;
    }

    public void SliderFill(float countedSlider, int countedText)
    {
        if (Star1Limit == 0 || Star2Limit == 0 || Star3Limit == 0)
        {
            Debug.LogError("Star1Limit - Star2Limit - Star3Limit variables are not assigned through with SetStarsLimit(int star1Limit, int star2Limit, int star3Limit) function...  (MainSliderController)");
            //UnityEditor.EditorApplication.isPlaying = false;
        }

        if (countedSlider > Star1Limit && star1Done == false)
        {
            star1Done = true;
            smallStars[0].GetComponent<Animation>().Play();
            //bigStars[0].enabled = true;
        }
        else if (countedSlider < Star1Limit && star1Done == true)
        {
            star1Done = false;
            // bigStars[0].enabled = false;
        }

        if (countedSlider > Star2Limit && star2Done == false)
        {
            star2Done = true;
            smallStars[1].GetComponent<Animation>().Play();
            //bigStars[1].enabled = true;
        }
        else if (countedSlider < Star2Limit && star2Done == true)
        {
            star2Done = false;
            //bigStars[1].enabled = false;
        }

        if (countedSlider > Star3Limit && star3Done == false)
        {
            star3Done = true;
            smallStars[2].GetComponent<Animation>().Play();
            // bigStars[2].enabled = true;
        }
        else if (countedSlider < Star3Limit && star3Done == true)
        {
            star3Done = false;
            //bigStars[2].enabled = false;
        }

        MainSlider.value = countedSlider;
        TextCount.text = countedText.ToString();
    }







}
