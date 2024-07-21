using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevelBtn : MonoBehaviour
{
    [SerializeField] Button restartBtn;
    public string prefabName;

    private void Start()
    {
        restartBtn.onClick.AddListener(RestartLevel);
    }

    void RestartLevel()
    {
        Debug.Log("restartlevel");
        ActionManager.OnRestartLevel?.Invoke();
    }
}
