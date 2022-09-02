using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int flyForce = 100;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticles;
    
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

    // Accelerate UP method
    void Accelerate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartBoosting();
        }
        else
        {
            StopBoosting();
        }
    }

    void StartBoosting()
    {
        rb.AddRelativeForce(Vector3.up * flyForce * Time.deltaTime);

        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
    }

    private void StopBoosting()
    {
        mainEngineParticles.Stop();
        audioSource.Stop();
    }
}
