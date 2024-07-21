using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] Button playBtn;
    [SerializeField] string sceneName;

    private void LoadSceneByName()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Start()
    {
        playBtn.onClick.AddListener(LoadSceneByName);
    }
}
