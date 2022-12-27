using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Camera mainCamera;
    protected Joystick joystick;

    private Vector3 moveDir = Vector3.zero;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        if (ScoreManager.Instance.GetLevelStatus() == LevelStatusEnum.Ready)
        {

        }
        else if (ScoreManager.Instance.GetLevelStatus() == LevelStatusEnum.Continues)
        {
            TouchListener();
            SetCameraPosition();
        }
        else
        {

        }
    }          

    public void TouchListener()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    break;
                case TouchPhase.Moved:
                    PlayerMove();
                    break;
                case TouchPhase.Ended:
                    break;
                case TouchPhase.Stationary:
                    PlayerMove();
                    break;
            }
        }
    }



    public void PlayerMove()
    {
        //https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483

        Rigidbody rb = transform.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(joystick.Horizontal * Constant.Joystick_PlayerSpeed, rb.velocity.y, joystick.Vertical * Constant.Joystick_PlayerSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rb.velocity), Time.deltaTime * Constant.Joystick_PlayerRotation);
    }

    private void SetCameraPosition()
    {
        mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, transform.position.z - 7.8f);
    }


}
