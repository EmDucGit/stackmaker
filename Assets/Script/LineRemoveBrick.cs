using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRemoveBrick : MonoBehaviour
{
    [SerializeField] GameObject brick;
    [SerializeField] BoxCollider hitbox;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("hit");
            brick.SetActive(true);
            hitbox.enabled = false;
        }
        ActionManager.OnRemoveBrick?.Invoke();
    }

    private void Start()
    {
        ActionManager.OnRestartLevel += OnInit;
    }

    void OnInit()
    {
        if (brick.gameObject == null)
        {
            Debug.Log("null");
        }
        //brick.SetActive(false);
        hitbox.enabled = true;
    }

    private void OnDestroy()
    {
        ActionManager.OnRestartLevel -= OnInit;
    }
}
