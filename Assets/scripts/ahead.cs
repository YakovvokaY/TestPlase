using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ahead : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject trunk;
    [SerializeField] Transform aheadObj;
    private float dist;
    private HashSet<Transform> Obj = new HashSet<Transform>();
    private Vector3 Position1X;
    private int flag;
    void FixedUpdate()
    {
        foreach (Transform body in Obj)
        {
            if (body.tag == "Player")
            {
                dist = (transform.position - aheadObj.position).magnitude;
                StartCoroutine(moveVector());
                if (flag==0)
                {
                    StartCoroutine(faire());
                }
            }
            transform.LookAt(aheadObj);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Obj.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Obj.Remove(other.transform);
        }
    }
    IEnumerator moveVector()
    {
        yield return new WaitForSeconds(0.001f);
        foreach (Transform body in Obj)
        {
            if (body.tag == "Player")
            {
                Position1X = body.position;
            }
        }

        yield return new WaitForSeconds(0.001f);

        foreach (Transform body in Obj)
        {
            if (body.tag == "Player")
            {
                aheadObj.position = (body.position - Position1X)*dist*1.6f + body.position;
            }
        }
        StopCoroutine(moveVector());
    }
    IEnumerator faire()
    {
        flag = 1;
        yield return new WaitForSeconds(1);
        Instantiate(bullet,trunk.transform.position,transform.rotation);
        yield return new WaitForSeconds(1);
        StopCoroutine(faire());
        flag = 0;
    }
}