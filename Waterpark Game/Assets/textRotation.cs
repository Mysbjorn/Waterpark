using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textRotation : MonoBehaviour
{
    private Camera theCam;

    private void Start()
    {
        theCam = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(theCam.transform);
    }

}
