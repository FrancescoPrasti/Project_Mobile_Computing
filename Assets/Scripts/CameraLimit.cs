using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    GameObject target;
    public CinemachineVirtualCamera VCam;
    private CinemachineComponentBase componentBase;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        componentBase = VCam.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }

    // Update is called once per frame
    void Update()
    {
        if(target.transform.position.x >= 82f)
            {
                if (componentBase is CinemachineFramingTransposer) {
                    var framingTransposer = componentBase as CinemachineFramingTransposer;
                    framingTransposer.m_SoftZoneWidth = 2;
                    framingTransposer.m_DeadZoneWidth = 2;
                }
            }
    }
}
