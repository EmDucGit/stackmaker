using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    Vector3 offset = new Vector3(0f, 10f, -10f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position + offset, 0.04f);
            transform.position = smoothedPosition;
        }
    }

    void OnInit()
    {
        GameObject targetObject = GameObject.FindWithTag("Player");
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
        transform.position = target.position;
    }
}

