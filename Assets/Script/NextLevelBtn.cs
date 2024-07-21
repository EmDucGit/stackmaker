using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelBtn : MonoBehaviour
{
    [SerializeField] Button nextLevelBtn;
    public string prefabName;

    private void Start()
    {
        nextLevelBtn.onClick.AddListener(NextLevel);
    }

    void NextLevel()
    {
        ActionManager.OnNextLevel?.Invoke();
    }
}
