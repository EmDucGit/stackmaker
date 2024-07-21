using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectBtn : MonoBehaviour
{
    [SerializeField] string prefabName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnLevel()
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);
        // Kiểm tra nếu prefab tồn tại
        if (prefab != null)
        {
            Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Prefab with name " + prefabName + " not found in Resources folder.");
        }
    }
}
