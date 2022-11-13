using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourForse : MonoBehaviour
{
    public Vector3 forse;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(forse);
    }
}