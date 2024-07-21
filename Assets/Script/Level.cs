using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ActionManager.OnNextLevel += DeleteLevel;
        ActionManager.OnStartLevel?.Invoke();
        PlayerPrefs.SetString("currLevel", gameObject.name);
    }

    void DeleteLevel()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        ActionManager.OnNextLevel -= DeleteLevel;
    }
}
