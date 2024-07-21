using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
    public const float MAX_SWIPE_TIME = 0.5f;



    // Factor of the screen width that we consider a swipe
    // 0.17 works well for portrait mode 16:9 phone
    public const float MIN_SWIPE_DISTANCE = 0.17f;
    private bool isSwipe = false;
    private bool onPush = false;
    private bool canCheckSwipe = true;
    [SerializeField] Animator model;
    [SerializeField] Transform test;

    Vector3 endpos, startPoint;
    RaycastHit raycast;
    public LayerMask layer;
    Vector2 startPos;
    float startTime;


    private void Start()
    {
        startPoint = transform.position;
        ActionManager.OnWinPos += OnWin;
        ActionManager.OnRestartLevel += OnRestart;
        ActionManager.OnNextLevel += OnRestart;
    }

    public void Update()
    {
        if (canCheckSwipe)
        {
            CheckSwipe();
        }

        if (isSwipe || onPush)
        {
            Move();
        }

        if(Vector3.Distance(transform.position, endpos) <= 0.001f)
        {
            Stop();
        }
    }

    private void CheckSwipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
                startTime = Time.time;
            }
            if (t.phase == TouchPhase.Ended)
            {
                if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                    return;

                Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);

                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                    return;
                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                { // Horizontal swipe
                    if (swipe.x > 0)
                    {
                        //right
                        transform.rotation = Quaternion.Euler(0, 90, 0);
                        CheckWall();
                        isSwipe = true;
                        canCheckSwipe = false;
                        Debug.Log("vuot phai");
                    }
                    else
                    {
                        //left
                        transform.rotation = Quaternion.Euler(0, -90, 0);
                        CheckWall();
                        isSwipe = true;
                        canCheckSwipe = false;
                        Debug.Log("vuot trai");
                    }
                }
                else
                { // Vertical swipe
                    if (swipe.y > 0)
                    {
                        //up
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        CheckWall();
                        isSwipe = true;
                        canCheckSwipe = false;
                        Debug.Log("vuot len");
                    }
                    else
                    {
                        //down
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        CheckWall();
                        isSwipe = true;
                        canCheckSwipe = false;
                        Debug.Log("vuot xuong");
                    }
                }
            }
        }
    }



    private void CheckWall()
    {
        for (int i = 1; i < 999; i++)
        {
            //Vị trí ray bắt đầu cách nhân vật 1 đơn vị
            Vector3 rayOrigin = transform.position + transform.forward * i;
            //Hướng của tia ray bắn xuống
            Vector3 rayDirection = -transform.up;
            Physics.Raycast(rayOrigin, rayDirection, out raycast, 1f, layer);
            Debug.DrawRay(rayOrigin, rayDirection * 1f, Color.red);
            if(raycast.collider == null)
            {
                continue;
            } else if (raycast.collider.tag == "wall")
            {
                endpos = transform.position + transform.forward * (i - 1);
                break;
            } else
            {
                return;
            }
        }
    }

    private void Move()
    {
        canCheckSwipe = false;
        transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * 15f);
    }

    private void Stop()
    {
        canCheckSwipe = true;
        onPush = false;
    }

    private void OnWin()
    {
        model.SetInteger("renwu", 2);
        this.enabled = false;
    }

    private void OnRestart()
    {
        transform.position = startPoint;
        model.SetInteger("renwu", 0);
        this.enabled = true;
        endpos = startPoint;
        Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "pushRight":
                transform.rotation = Quaternion.Euler(0, 90, 0);
                CheckWall();
                onPush = true;
                break;
            case "pushLeft":
                transform.rotation = Quaternion.Euler(0, -90, 0);
                CheckWall();
                onPush = true;
                break;
            case "pushBack":
                transform.rotation = Quaternion.Euler(0, 180, 0);
                CheckWall();
                onPush = true;
                break;
            case "pushFoward":
                transform.rotation = Quaternion.Euler(0, 0, 0);
                CheckWall();
                onPush = true;
                break;
        }
    }

}