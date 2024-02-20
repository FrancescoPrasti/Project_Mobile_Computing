using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;
    public Transform sideRightBG;
    public float length; //= 14.78f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(mainCam.position.x > sideBG.position.x)
            sideRightBG.position = middleBG.position + Vector3.right * length;
        if(mainCam.position.x > middleBG.position.x)
            sideBG.position = sideRightBG.position + Vector3.right * length;
        if(mainCam.position.x > sideRightBG.position.x)
            middleBG.position = sideBG.position + Vector3.right * length;
        /*if(mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x)
        {
            Transform z = middleBG;
            middleBG = sideBG;
            sideBG = z;
        }*/
    }
}
