using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickVisual : MonoBehaviour
{

    [SerializeField] GameObject brick;
    [SerializeField] GameObject model;
    private List<GameObject> brickList = new List<GameObject>();
    private int currBrick = 0;
    public void Start()
    {
        ActionManager.OnAddBrick += AddBrick;
        ActionManager.OnRemoveBrick += RemoveBrick;
        ActionManager.OnWinPos += ClearBrick;
        AddBrick();
    }

    private void AddBrick()
    {
        currBrick++;
        model.transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f * currBrick, transform.position.z);
        GameObject Brick = Instantiate(brick, new Vector3(transform.position.x, transform.position.y + 0.15f * (currBrick - 1), transform.position.z), transform.rotation, transform);
        brickList.Add(Brick);
    }

    private void RemoveBrick()
    {
        currBrick--;
        GameObject objectToDestroy = brickList[brickList.Count - 1];
        brickList.RemoveAt(brickList.Count - 1);
        Destroy(objectToDestroy);
        model.transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f * currBrick, transform.position.z);
    }

    private void ClearBrick()
    {
        currBrick = 0;
        foreach (GameObject obj in brickList)
        {
            Destroy(obj);
        }
        // Xóa các tham chiếu trong danh sách
        brickList.Clear();
        model.transform.position = new Vector3( model.transform.position.x, 0, model.transform.position.z);
    }

}
