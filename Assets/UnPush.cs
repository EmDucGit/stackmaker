using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPush : MonoBehaviour
{
    [SerializeField] BoxCollider turnOnCheck, pushBox;
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pushBox.enabled = false;
            turnOnCheck.enabled = true;
        }
    }
}
