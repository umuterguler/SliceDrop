using Assets.Scripts.Data.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private int actionStatus = Animator.StringToHash("ActionStatus");
    // private int fall = Animator.StringToHash("Fall");


    public void Init(Animator anim)
    {
        animator = anim;
    }


    public void SetActionStatus(PlayerAnimationEnum actionStatusEnum)
    {
        animator.SetInteger(actionStatus, (int)actionStatusEnum);
    }
    

    public void Fall()
    {
        animator.SetTrigger("Fall");
    }


}
