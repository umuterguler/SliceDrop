using Assets.Scripts.Data.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterController : MonoBehaviour
{
    //GameObjects
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject BallParent;
    [SerializeField] private GameObject RaycastObject;
    [SerializeField] private ParticleSystem PuffParticle;


    //CoreColor Veriables
    private RaycastHit hit;
    private int colorObject = 0;    

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_ROLL))
        {
            try
            {
                Instantiate(PuffParticle);
                Physics.Raycast(RaycastObject.transform.position, RaycastObject.transform.TransformDirection(Vector3.forward), out hit, 50f);

                var hitComponent = hit.collider.transform.GetChild(1).GetChild(colorObject);
                GameObject newBall = Instantiate(Ball, BallParent.transform);
                newBall.GetComponent<MeshRenderer>().material = hitComponent.GetComponent<MeshRenderer>().material;
                newBall.GetComponent<CoreColorModel>().ColorType = hitComponent.GetComponent<CoreColorModel>().ColorType;                
                colorObject = colorObject + 1;
                Destroy(other.gameObject);
                ScoreManager.Instance.ballCount = BallParent.transform.childCount;
                ScoreManager.Instance.LevelFinish();


            }
            catch (System.Exception Ex)
            {
                string ss = Ex.Message;
            }         
        }
    }



}
