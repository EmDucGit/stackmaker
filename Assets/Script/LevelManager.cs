using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] GameObject player;
    [SerializeField] string prefabName;

    private void Start()
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

    void OnInit()
    {
        GameObject targetObject = GameObject.FindWithTag("startPoint");
        if (targetObject != null)
        {
            startPoint = targetObject.transform;
        }
        Instantiate(player, new Vector3(startPoint.position.x, 0.15f, startPoint.position.z), startPoint.rotation);
    }
}
