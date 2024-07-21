using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : MonoBehaviour
{
    [SerializeField] GameObject chestOpen;
    [SerializeField] GameObject chestClose;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            chestOpen.SetActive(true);
            chestClose.SetActive(false);
            ActionManager.OnWinPos?.Invoke();
        }
    }

    private void Start()
    {
        ActionManager.OnRestartLevel += OnInit;
    }

    void OnInit()
    {
        chestOpen.SetActive(false);
        chestClose.SetActive(true);
    }

    private void OnDestroy()
    {
        ActionManager.OnRestartLevel -= OnInit;
    }
}
