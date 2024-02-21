using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class Keyboard : MonoBehaviour
{

    System.Diagnostics.Process p;

  
    private void Update()
    {
        try
        {
            if (p.HasExited)
            {
                Debug.Log("Process end");
            }
            else
            {
                Debug.Log("Process Running");
            }
        }
        catch (Exception rx)
        {
        }
    }

    public void OnBtnClick()
    {
        try
        {
            p = System.Diagnostics.Process.Start("OSK.exe");
        }
        catch (Exception rx) { }
    }

}
