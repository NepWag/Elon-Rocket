using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject BlendCamera, MainCamera;
    void Start()
    {
        BlendCamera.SetActive(false);
        MainCamera.SetActive(true);
    }
}
