using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] int flyForce = 50;
    [SerializeField] int rotationForce = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Accelerate();
        Rotate();
    }

    void Accelerate()
    {
        //Accelerate up
        if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.AddRelativeForce(Vector3.up * flyForce * Time.deltaTime);
        }     
    }

    void Rotate()
    {
        
        if (Input.GetKey(KeyCode.RightArrow)) //Rotate right
        {
            ApplyRotation(-rotationForce);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) //Rotate Left
        {
            ApplyRotation(rotationForce);
        }
    }

    private void ApplyRotation(int rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
