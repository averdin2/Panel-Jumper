using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private float yMin;

    private Transform target;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Character").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        setYMin(target);    //comment for regular follow camera
        transform.position = new Vector3(0, Mathf.Clamp(target.position.y, yMin, float.MaxValue), transform.position.z);
    }

    public void setYMin(Transform t)
    {
        if (t.position.y > yMin)
        {
            yMin = t.position.y;
        }
    }
}
