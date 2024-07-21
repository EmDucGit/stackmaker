using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{
    private enum typePush
    {
        PushRightAndBack,
        PushLeftAndBack,
        PushRightAndFoward,
        PushLeftAndFoward
    }

    private typePush typepush;

    [SerializeField] BoxCollider box1, box2, box3, box4;
    [SerializeField] public GameObject pushVisual;
    RaycastHit checkLeft, checkRight, checkBack, checkFoward;
    public LayerMask layer;

    private void Update()
    {
        CheckTypePush();
    }

    void CheckTypePush()
    {
        //Check 4 hướng của pushblock
        Vector3 origin = new Vector3(transform.position.x, -1, transform.position.z);

        Physics.Raycast(origin, Vector3.back, out checkBack, 1.2f, layer);
        Physics.Raycast(origin, Vector3.forward, out checkFoward, 1.2f, layer);
        Physics.Raycast(origin, Vector3.left, out checkLeft, 1.2f, layer);
        Physics.Raycast(origin, Vector3.right, out checkRight, 1.2f, layer);

        Debug.DrawRay(origin, Vector3.back, Color.red);
        Debug.DrawRay(origin, Vector3.forward, Color.red);
        Debug.DrawRay(origin, Vector3.left, Color.red);
        Debug.DrawRay(origin, Vector3.right, Color.red);

        //xác định hướng để push nhân vật
        if (checkLeft.collider != null && checkFoward.collider != null)
        {
            typepush = typePush.PushRightAndBack;
            ChangeTypePush();
        }
        else if (checkFoward.collider != null && checkRight.collider != null)
        {
            typepush = typePush.PushLeftAndBack;
            ChangeTypePush();
        }
        else if (checkRight.collider != null && checkBack.collider != null)
        {
            typepush = typePush.PushLeftAndFoward;
            ChangeTypePush();
        }
        else if (checkLeft.collider != null && checkBack.collider != null)
        {
            typepush = typePush.PushRightAndFoward;
            ChangeTypePush();
        }
        else
        {
            return;
        }
    }

    void ChangeTypePush()
    {
        //thay đổi các hitbox để push nhân vật cho hợp lý + xoay pushvisual
        switch (typepush)
        {
            case typePush.PushLeftAndBack:
                pushVisual.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                box1.enabled = true;
                box2.enabled = true;
                box3.enabled = false;
                box4.enabled = false;
                box1.gameObject.tag = "pushLeft";
                box2.gameObject.tag = "pushBack";
                break;
            case typePush.PushLeftAndFoward:
                pushVisual.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                box1.enabled = false;
                box2.enabled = true;
                box3.enabled = true;
                box4.enabled = false;
                box3.gameObject.tag = "pushLeft";
                box2.gameObject.tag = "pushFoward";
                break;
            case typePush.PushRightAndBack:
                pushVisual.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
                box1.enabled = true;
                box2.enabled = false;
                box3.enabled = false;
                box4.enabled = true;
                box1.gameObject.tag = "pushRight";
                box4.gameObject.tag = "pushBack";
                break;
            case typePush.PushRightAndFoward:
                pushVisual.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                box1.enabled = false;
                box2.enabled = false;
                box3.enabled = true;
                box4.enabled = true;
                box3.gameObject.tag = "pushRight";
                box4.gameObject.tag = "pushFoward";
                break;
        }
    }
}
