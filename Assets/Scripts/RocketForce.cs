using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <Summary>
///  Force on the rocket 
/// </Summary>
public class RocketForce : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private bool IsRocketOn;
    private bool IsSoundOn;
    void Start()
    {
        IsRocketOn = false;
        IsSoundOn = false;
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
       if(IsSoundOn == false)
       {
           AudioManager.instance.RocketSound();
           IsSoundOn = true;
       }
   }

   public void OnPointerUp(PointerEventData eventData)
   {
       IsRocketOn = false;
       IsSoundOn = false;
   }
}
