using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <Summary>
///  MiniMap Camera
/// </Summary>
public class TopCamera : MonoBehaviour
{
    public GameObject Rocket;
    void Update()
    {
         transform.position = new Vector3( Rocket.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
}
