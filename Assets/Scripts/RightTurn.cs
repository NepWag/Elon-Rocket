using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <Summary>
/// Right Turn Control
/// </Summary>
public class RightTurn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool IsRightOn;
    void Start()
    {
        IsRightOn = false;
    }
    
    void Update()
    {
        if(IsRightOn == true)
        {
           Movement.instance.RightTurn();
        }
    }

   public void OnPointerDown(PointerEventData eventData)  
   {
       IsRightOn = true;
   }

   public void OnPointerUp(PointerEventData eventData)
   {
       IsRightOn  = false;
   }
}
