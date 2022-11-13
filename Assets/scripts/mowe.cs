using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mowe : MonoBehaviour
{
    public float speed;
    public float Jumpforse;
    private Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
            {
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        
        Vector3 movementDelta = new Vector3(moveH, 0, moveV);

        movementDelta = Vector3.ClampMagnitude(movementDelta, 1) * speed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movementDelta);


    }
    void Jump()
    {
        Vector3 forse = Vector3.up * Jumpforse;
        rb.AddForce(forse, ForceMode.Acceleration);
    }
}
