using Assets.Scripts.Data.Enums;
using Assets.Scripts.Data.Models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textSlogan;



    void Start()
    {

    }

    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.TAG_BALL))
        {
            GameObject ball = other.gameObject;

            if (ball.GetComponent<EnteredTypeModel>().EnterType == EnterTypeEnum.NonEntered)
            {
                TextMeshPro slogan = Instantiate(textSlogan, other.transform.position, textSlogan.transform.rotation, this.gameObject.transform);

                if (ball.GetComponent<CoreColorModel>().ColorType == this.GetComponent<CoreColorModel>().ColorType)
                {
                    ScoreManager.Instance.SliceRightAdd();
                    slogan.SetText(ScoreManager.Instance.RandomSloganGood());
                    slogan.color = Color.green;                   
                }
                else
                {
                    //ScoreManager.Instance.score -= 1;
                    slogan.SetText(ScoreManager.Instance.RandomSloganBad());
                    slogan.color = Color.red;                   
                }
                slogan.GetComponent<Animator>().Play("SloganUp");
                Destroy(slogan, 2f);
            }
            ball.GetComponent<EnteredTypeModel>().EnterType = EnterTypeEnum.Entered;
        }
    }









}
