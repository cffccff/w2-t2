using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    Vector3 targetPoint;

    int index_point = 1;
    string point = "Point_";
    string point_position;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = GameObject.Find("Point_1").transform.position;


    }
    void move_gameobject()
    {
        float step = 4 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
        if (Vector3.Distance(transform.position, targetPoint) < 0.001f)
        {
            if (index_point == 4)
            {
                index_point = 1;
            }
            else
            {
                index_point++;
            }

            point_position = point + index_point.ToString();
            targetPoint = GameObject.Find(point_position).transform.position;
        }
    }
    void rotate_gameobject()
    {
        transform.LookAt(targetPoint);
      
    }
    void Update()
    {
        move_gameobject();
        rotate_gameobject();
    }
    

}
