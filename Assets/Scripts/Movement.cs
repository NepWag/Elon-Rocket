using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 50f;
    Rigidbody rb;
    public static Movement instance;

    void Awake(){
        if(instance == null)
        {
            instance = this;
        }
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
             PointManager.instance.AddPoint();
		     Destroy(collision.gameObject);
	   }
       else if (collision.gameObject.tag == "Landing")
	   {
             Destroy(collision.gameObject);
       }
       else if (collision.gameObject.tag == "Sea")
	   {

       }
    }
} 
