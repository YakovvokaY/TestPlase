using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMowe : MonoBehaviour
{
    [SerializeField] Transform fovardPoint;
    private float mouseX;
    private float mouseY;
    private Rigidbody rb;
    private float Zax = 70;
    private float ZupAx = 100;
    private float speed = 100;
    private float mouseScrl;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * 400;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 400;

        speed = speed + mouseScrl;

        transform.Rotate(mouseX * new Vector3(0, 0, 1));
        transform.Rotate(-mouseY * new Vector3(1, 0, 0));

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce((fovardPoint.position-transform.position).normalized * Time.deltaTime*300);
        }
        /*if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }*/


        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 1, 0) * -Zax * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Zax * Time.deltaTime);
        }
    }
}