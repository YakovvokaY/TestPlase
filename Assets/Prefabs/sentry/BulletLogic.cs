using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] Transform Point;
    private Rigidbody rb;
    void Start()
    {
        Vector3 direction = (transform.position - Point.position).normalized;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce((Point.position - transform.position).normalized * 300);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}