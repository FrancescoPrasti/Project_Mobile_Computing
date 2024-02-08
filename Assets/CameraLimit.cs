using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    public Transform target;
    public GameObject wall;
    float pos;
    float newPos;
    void Start()
    {
        pos = target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = target.position.x;
        if(newPos != pos)
        {
            Vector3 temp = new Vector3(newPos - pos, 0, 0);
            wall.transform.position += temp;
            pos = newPos;
        }
    }
}
