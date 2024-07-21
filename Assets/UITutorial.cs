using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UITutorial : MonoBehaviour
{
    [SerializeField] GameObject cusor;
    private Vector3 point1 = new Vector3(-100, -50, 0);
    private Vector3 point2 = new Vector3(200, -50, 0);
    private Vector3 target;

    private void Start()
    {
        cusor.transform.position = point1;
        target = point2;
    }

    private void Update()
    {
        cusor.transform.position = Vector3.MoveTowards(transform.position, target, 1f * Time.deltaTime);

        // Khi đối tượng đạt đến vị trí mục tiêu, đổi mục tiêu sang điểm còn lại
        if (Vector3.Distance(cusor.transform.position, target) < 0.1f)
        {
            target = point2;
        }
    }
}
