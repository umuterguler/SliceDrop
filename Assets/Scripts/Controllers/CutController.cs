using BzKovSoft.ObjectSlicer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutController : MonoBehaviour
{
    public static CutController Instance;

    public CutController()
    {
        Instance = this;
    }

    void Start()
    {

    }
    void Update()
    {

    }


    public void Cut(GameObject target)
    {
        var sliceable = target.GetComponent<IBzSliceableAsync>();
        if (sliceable == null)
        {
            return;
        }

        Plane plane = new Plane(Vector3.right, 0f);
        sliceable.Slice(plane, 0, null);
    }




}
