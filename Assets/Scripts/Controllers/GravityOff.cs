using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOff : MonoBehaviour
{
    [SerializeField] private GameObject GravityTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_FILTER))
        {
            GravityTrigger.GetComponent<Collider>().isTrigger = false;
        }
    }
}
