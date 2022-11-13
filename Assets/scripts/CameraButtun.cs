using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraButtun : MonoBehaviour
{
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject Main_Camera;
    public void change()
    {
        if (Input.GetMouseButton(0))
        {
            (Camera.GetComponent<Camera>()).enabled = false;
        }
    }
}
