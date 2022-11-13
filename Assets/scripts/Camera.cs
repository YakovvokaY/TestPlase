using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    //private float mouseWheel;
    private float Zax = 70;
    private float ZupAx = 100;
    private float speed = 50;
    private float mouseScrl;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * 400;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * 400;
        mouseScrl = Input.GetAxis("Mouse ScrollWheel");

        ZupAx = ZupAx + mouseScrl;
        speed = speed + mouseScrl;

        transform.Rotate(mouseX * new Vector3(0,1,0));
        transform.Rotate(-mouseY * new Vector3(1,0,0));

        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate (new Vector3(0,0,1)* Zax * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, 1) * -Zax *Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            transform.localPosition += transform.up * ZupAx * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localPosition += -transform.up * ZupAx * Time.deltaTime;
        }
    }
}