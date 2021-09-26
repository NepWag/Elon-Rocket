using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftTurn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    private bool IsLeftOn;
    void Start()
    {
        IsLeftOn = false;
    }
    
    void Update()
    {
        if(IsLeftOn == true)
        {
           Movement.instance.LeftTurn();
        }
    }

   public void OnPointerDown(PointerEventData eventData)  
   {
       IsLeftOn = true;
   }

   public void OnPointerUp(PointerEventData eventData)
   {
       IsLeftOn  = false;
   }
}
