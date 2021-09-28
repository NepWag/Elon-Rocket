using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPlatform : MonoBehaviour
{
    public Transform Rocket;
    float angleZ;
    float passValue;
    public GameObject CongratPlatfrom;
    public static FinishPlatform instance;
    public bool IsInsideBox;
    public AudioSource victory;
    

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        IsInsideBox =  false;
    }

    public void CheckTheRocket()
    {
        IsInsideBox = true;
        StartCoroutine("passfunc");
    }

    public void PassLevel()
    {
        if(IsInsideBox == true)
        {  
            angleZ = Rocket.transform.localEulerAngles.z;
            if(passValue <= 45f || passValue >= 315f)
            {
                 CongratPlatfrom.SetActive(true);
                 victory.Play();
            }
        }
        else
        {
             GameManager.instance.GameOver();
        }
    }

    public void CancelInvokeCheckRocket()
    {
         CancelInvoke();
         IsInsideBox = false;
    }

    IEnumerator passfunc() 
    {
           yield return new WaitForSecondsRealtime(3); 
           PassLevel();
    }
}
