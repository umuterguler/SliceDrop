using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RunnerController : MonoBehaviour
{

    private Vector3 moveDir = Vector3.zero;
    private Vector3 newPosi;


    #region DirectionController Variables
    private float startingPosition;
    private float timer;
    #endregion


    void Update()
    {
        if (ScoreManager.Instance.GetLevelStatus() == LevelStatusEnum.Ready)
        {

        }
        else if (ScoreManager.Instance.GetLevelStatus() == LevelStatusEnum.Continues)
        {
            DirectionSwipeListener();
            ClampXPos();
        }
        else
        {

        }

    }

    void DirectionSwipeListener()
    {
        Transform chieldTran = transform.GetChild(0).transform;
        Rigidbody rb = transform.GetComponent<Rigidbody>();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startingPosition = touch.position.x;
                    break;
                case TouchPhase.Moved:
                    if (startingPosition > touch.position.x)
                    {
                        //Left
                        newPosi = new Vector3(-1, transform.position.y, transform.position.z);
                        startingPosition = touch.position.x;
                    }
                    else
                    {
                        //Right
                        newPosi = new Vector3(1, transform.position.y, transform.position.z);
                        startingPosition = touch.position.x;
                    }

                    rb.velocity = newPosi * Constant.Runner_PlayerManeuver;
                    break;
                case TouchPhase.Ended:
                    newPosi = new Vector3(0, transform.position.y, transform.position.z);
                    rb.velocity = newPosi * Constant.Runner_PlayerManeuver;
                    break;
                case TouchPhase.Stationary:
                    newPosi = new Vector3(0, transform.position.y, transform.position.z);
                    rb.velocity = newPosi * Constant.Runner_PlayerManeuver;
                    break;
            }
        }
    }
    void ClampXPos()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -4.3f, 2.8f);
        transform.position = pos;
    }


}
