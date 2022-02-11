using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cameraSpring;

    public void ActivateCamera()
    {
        cameraSpring.SetActive(true);
    }

    public void DesactivateCamera()
    {
        cameraSpring.SetActive(false);
    }
}
