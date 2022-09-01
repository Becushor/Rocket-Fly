using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int flyForce = 100;
    [SerializeField] AudioClip mainEngine;
    
    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Accelerate();
    }

    void Accelerate()
    {
        //Accelerate up
        if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.AddRelativeForce(Vector3.up * flyForce * Time.deltaTime);

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else
            audioSource.Stop();
    }

}
