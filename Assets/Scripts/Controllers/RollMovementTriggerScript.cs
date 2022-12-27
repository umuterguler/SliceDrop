using Assets.Scripts.Data.Enums;
using Assets.Scripts.Data.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollMovementTriggerScript : MonoBehaviour
{
    //GameObjects
    [SerializeField] private GameObject rollObject;
    [SerializeField] private GameObject rollInside;
    [SerializeField] private GameObject Knife;

    private PlayerAnimation playerAnimation = new PlayerAnimation();

    //RollMovement
    private float moveAmount = 0.9f;
    private int childNumber = 0;
    private Vector3 movePos;

    private void Start()
    {
        playerAnimation.Init(Knife.transform.GetComponent<Animator>());
    }

    private void OnTriggerEnter(Collider other)
    {
        var childPos = rollObject.transform.GetChild(childNumber).transform.position;
        movePos = new Vector3(childPos.x + moveAmount, childPos.y, childPos.z);

        if (other.CompareTag(Constant.TAG_PLAYER))
        {
            rollObject.transform.GetChild(childNumber).GetComponent<Rigidbody>().MovePosition(movePos);

            if (ScoreManager.Instance.sliceCount - 1 == ScoreManager.Instance.ballCount)
            {
                playerAnimation.SetActionStatus(PlayerAnimationEnum.Run);
            }
        }
    }
}
