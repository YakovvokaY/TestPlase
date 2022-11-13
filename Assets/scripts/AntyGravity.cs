using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntyGravity : MonoBehaviour
{
    private HashSet<Rigidbody> fb = new HashSet<Rigidbody>();
    private Rigidbody compRigib;
    [SerializeField] private float AGF = 100;
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
            float grForse = (AGF / (distanse * distanse));
            body.AddForce(-direction * grForse);
            compRigib.AddForce(direction * grForse);
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
