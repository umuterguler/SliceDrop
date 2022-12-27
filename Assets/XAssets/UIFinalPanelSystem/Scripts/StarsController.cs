using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsController : MonoBehaviour
{
    public static StarsController Instance;

    public enum StarsEnum
    {
        ZeroStar,
        OneStar,
        TwoStar,
        ThreeStar
    }

    [SerializeField]
    private Image Star1, Star2, Star3;

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



    public void SetStars(StarsEnum starsEnum)
    {
        switch (starsEnum)
        {
            case StarsEnum.ZeroStar:
                Star1.enabled = false;
                Star2.enabled = false;
                Star3.enabled = false;
                break;
            case StarsEnum.OneStar:
                Star1.enabled = true;
                Star2.enabled = false;
                Star3.enabled = false;
                break;
            case StarsEnum.TwoStar:
                Star1.enabled = true;
                Star2.enabled = true;
                Star3.enabled = false;
                break;
            case StarsEnum.ThreeStar:
                Star1.enabled = true;
                Star2.enabled = true;
                Star3.enabled = true;
                break;

            default:
                break;
        }

    }




}
