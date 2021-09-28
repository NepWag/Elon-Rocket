using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 50f;
    Rigidbody rb;
    public static Movement instance;
    public AudioSource Scan;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        InvokeRepeating("RepositionRocket",3f,3f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    public void LeftTurn()
    {
        ApplyRotation(rotationThrust);
    }

    public void RightTurn()
    {
         ApplyRotation(-rotationThrust);
    }

    public void UpForce()
    {
         rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the physics system can take over
    }

    void OnTriggerEnter(Collider collision)
    {
	   if (collision.gameObject.tag == "Gem")
	   {
             AudioManager.instance.CoinSound();
             PointManager.instance.AddPoint();
		     Destroy(collision.gameObject);
	   }
       else if (collision.gameObject.tag == "Landing")
	   {
             Destroy(collision.gameObject);
       }
       else if (collision.gameObject.tag == "Sea")
	   {  
             AudioManager.instance.SplashSound();
             GameManager.instance.GameOver();
       }
       else if (collision.gameObject.tag == "Finish")
       {
             Scan.Play();
             GameManager.instance.DisableButton();
             CheckRocket();
       }
    }

    void OnTriggerExit(Collider collision)
    {
       if (collision.gameObject.tag == "Finish")
	   {
           FinishPlatform.instance.CancelInvokeCheckRocket();
           FinishPlatform.instance.IsInsideBox = false;
           GameManager.instance.GameOver();
       }
    }

    void CheckRocket()
    {
        FinishPlatform.instance.CheckTheRocket();
    }

    void RepositionRocket()
    {
         this.transform.rotation = Quaternion.Euler(0f,0f,transform.eulerAngles.z);
    }
} 
