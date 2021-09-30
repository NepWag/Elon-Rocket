using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <Summary>
///  Camera Switch System
/// </Summary>
public class CameraSwitch : MonoBehaviour
{
    public GameObject BlendCamera, MainCamera;
    void Start()
    {
        BlendCamera.SetActive(false);
        MainCamera.SetActive(true);
    }
}
