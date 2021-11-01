using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSizeChanger : MonoBehaviour
{
    public float speed;
    public float upperBound;
    public float lowerBound;
    bool growing = true;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 upper = new Vector3(upperBound, upperBound, upperBound);
        //Vector3 lower = new Vector3(lowerBound, lowerBound, lowerBound);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= lowerBound)
        {
            growing = true;
        }
        if (transform.localScale.x >= upperBound)
        {
            growing = false;
        }
        float rate = speed * Time.deltaTime;
        if (growing)
        {
            transform.localScale = new Vector3(transform.localScale.x + rate, transform.localScale.y + rate, transform.localScale.z + rate);
        } else
        {
            transform.localScale = new Vector3(transform.localScale.x - rate, transform.localScale.y - rate, transform.localScale.z - rate);
        }

    }
}
