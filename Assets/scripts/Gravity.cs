using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravity : MonoBehaviour
{
    private HashSet<Rigidbody> fb = new HashSet<Rigidbody>();
    private Rigidbody compRigib;
    void Start()
    {
        compRigib = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        foreach (Rigidbody body in fb)
        {
            Vector3 direction = (transform.position - body.position).normalized;
            float distanse = (transform.position - body.position).magnitude;
            float grForse = (body.mass * compRigib.mass / (distanse * distanse));
            body.AddForce(direction * grForse );
            compRigib.AddForce(-direction * grForse );
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            fb.Add(other.attachedRigidbody);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            fb.Remove(other.attachedRigidbody);
        }
    }
}