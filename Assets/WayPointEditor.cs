using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(WayPoint))]
public class WayPointEditor : Editor
{
    public GameObject cubePrefab;
    WayPoint t;
    Ray ray;
    void OnSceneGUI()
    {
        // get the chosen game object

        Vector3 mousePosition = Event.current.mousePosition;
         ray = HandleUtility.GUIPointToWorldRay(mousePosition);
        Debug.Log(ray);
        t = target as WayPoint;
        if (t == null || t.listWayPoint == null)
            return;
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            if (Event.current.keyCode == KeyCode.A)
            {
                Debug.Log("A pressed");
                CreateInstance();

            }
        }


        // grab the center of the parent
        //  Vector3 center = t.transform.position;

        // iterate over game objects added to the array...
        //for (int i = 0; i < t.listWayPoint.Length; i++)
        //{
        //    // ... and draw a line between them
        //    if (t.listWayPoint[i] != null)
        //        if (i == t.listWayPoint.Length - 1)
        //        {
        //            Handles.DrawLine(t.listWayPoint[i].transform.position, t.listWayPoint[0].transform.position);
        //        }
        //        else Handles.DrawLine(t.listWayPoint[i].transform.position, t.listWayPoint[i + 1].transform.position);
        //}

    }
    void CreateInstance()
    {
        float temp;
        int index=-1;
       for(int i=0;i< t.listMidPoint.Count; i++)
        {
            if (i == t.listMidPoint.Count - 1)
            {
                if (Vector3.Distance(t.listMidPoint[i], ray.origin) < Vector3.Distance(t.listMidPoint[0], ray.origin))
                {
                    temp = Vector3.Distance(t.listMidPoint[i], ray.origin);
                    index = i;
                }
                else
                {
                    temp = Vector3.Distance(t.listMidPoint[0], ray.origin);
                    index = i;
                }
            }
            else
            {
                if (Vector3.Distance(t.listMidPoint[i], ray.origin) < Vector3.Distance(t.listMidPoint[i+1], ray.origin))
                {
                    temp = Vector3.Distance(t.listMidPoint[i], ray.origin);
                    index = i;
                }
                else
                {
                    temp = Vector3.Distance(t.listMidPoint[i+1], ray.origin);
                    index = i;
                }
            }
            
        }
        Vector3 a;
        if (index == t.listWayPoint.Length - 1)
        {
             a = t.listWayPoint[index].transform.position + (t.listWayPoint[index].transform.position - t.listWayPoint[0].transform.position) / 2;
        }
        else
        {
             a = t.listWayPoint[index].transform.position + (t.listWayPoint[index].transform.position - t.listWayPoint[index + 1].transform.position) / 2;
        }
        Debug.LogFormat("Vector mid point: {0}", a);
        Instantiate(t.prefabs, a, Quaternion.identity);
      
    }
}
