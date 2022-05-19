using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CubeScript : MonoBehaviour
{
    Vector3 wayPoint_Position;
    public GameObject[] objects ;
    int wayPoint_index;
   
  
    // Start is called before the first frame update
    void Start()
    {
        InitialObjects();



    }
   void InitialObjects()
    {
        objects = GameObject.FindGameObjectsWithTag("WayPoint");
        wayPoint_Position = objects[0].transform.position;
        wayPoint_index = 0;
    }
    void move_gameobject()
    {

        objects = GameObject.FindGameObjectsWithTag("WayPoint");
        if (objects[wayPoint_index] != null)
        {
            wayPoint_Position = objects[wayPoint_index].transform.position;
            float step = 7 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, wayPoint_Position, step);
            if (Vector3.Distance(transform.position, wayPoint_Position) < 0.001f)
            {
                if (wayPoint_index == objects.Length - 1) wayPoint_index = 0;
                else wayPoint_index++;
            }
        }
        else
        {
            InitialObjects();
        }

      


    }
    void rotate_gameobject()
    {
        transform.LookAt(wayPoint_Position);

    }
    void Update()
    {
        move_gameobject();
        rotate_gameobject();
    
    }
    

    





    
}
