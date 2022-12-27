using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTouchController : MonoBehaviour
{
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER))
        {
            var coreTransform = transform.GetChild(0).transform.position;
            transform.GetChild(0).transform.position = new Vector3(coreTransform.x - 0.001f, coreTransform.y, coreTransform.z);     
        }
    }
}
