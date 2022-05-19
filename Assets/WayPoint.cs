using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    
    public GameObject[] listWayPoint;
    public GameObject prefabs;
    public List<Vector3> listMidPoint = new List<Vector3>();
    void InitialObjects()
    {
        listWayPoint = GameObject.FindGameObjectsWithTag("WayPoint");
        Debug.Log(listWayPoint.Length);
     
    
    }
    // Start is called before the first frame update
    void Start()
    {
        InitialObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDrawGizmos()
    {
        listWayPoint = GameObject.FindGameObjectsWithTag("WayPoint");
        Debug.Log(listWayPoint.Length);
        for (int i = 0; i < listWayPoint.Length; i++)
        {
            // ... and draw a line between them
            if (listWayPoint[i] != null)
                if (i == listWayPoint.Length - 1)
                {
                 Vector3 a=   listWayPoint[i].transform.position + (listWayPoint[i].transform.position - listWayPoint[0].transform.position) / 2;
                    listMidPoint.Add(a);
                    Gizmos.DrawLine(listWayPoint[i].transform.position, listWayPoint[0].transform.position);
                }
                else
                {
                    Vector3 a = listWayPoint[i].transform.position + (listWayPoint[i].transform.position - listWayPoint[i+1].transform.position) / 2;
                    listMidPoint.Add(a);
                    Gizmos.DrawLine(listWayPoint[i].transform.position, listWayPoint[i + 1].transform.position);
                }
        }
    }
}
