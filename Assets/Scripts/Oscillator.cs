using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 5f;

    float movementFactor;
    Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } //just to protect fron NaN error
        const float Tau = Mathf.PI * 2;
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * Tau);

        movementFactor = (rawSinWave + 1f) /2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
