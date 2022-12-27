using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOn : MonoBehaviour
{
    [SerializeField] private GameObject GravityTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_PLAYER))
        {
            GravityTrigger.GetComponent<Collider>().isTrigger = true;
        }
    }
}
