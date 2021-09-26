using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RocketForce : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private bool IsRocketOn;
    void Start()
    {
        IsRocketOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsRocketOn == true)
        {
           Movement.instance.UpForce();
        }
    }

   public void OnPointerDown(PointerEventData eventData)  
   {
       IsRocketOn = true;
   }

   public void OnPointerUp(PointerEventData eventData)
   {
       IsRocketOn = false;
   }
}
