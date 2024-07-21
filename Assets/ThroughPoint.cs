using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughPoint : MonoBehaviour
{
    [SerializeField] BoxCollider pushBox, boxCheck1, boxCheck2, boxCheck3;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            boxCheck1.enabled = false;
            boxCheck2.enabled = false;
            boxCheck3.enabled = false;
            pushBox.enabled = true;
        }
    }
}
