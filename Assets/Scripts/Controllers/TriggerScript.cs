using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreMovementTriggerScript : MonoBehaviour
{
    //GameObjects
    [SerializeField] private GameObject rollObject;
    [SerializeField] private GameObject rollInside;

    //
    private float moveAmount = 0.9f;
    private Vector3 movePos;
    private int childNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        movePos = new Vector3(rollObject.transform.GetChild(childNumber).transform.position.x + moveAmount, rollObject.transform.GetChild(childNumber).transform.position.y, rollObject.transform.GetChild(childNumber).transform.position.z);

        if (other.CompareTag(Constant.TAG_PLAYER))
        {
            rollObject.transform.GetChild(childNumber).GetComponent<Rigidbody>().MovePosition(movePos);
        }
    }
}
