using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmovement : MonoBehaviour
{
    float minX;
    float maxX;
    public float moveSpeed;
    bool going = true;
    // Start is called before the first frame update
    void Start()
    {
        minX = -9;
        maxX = 9;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= maxX)
        {
            going = true;
        }
        if (transform.position.x <= minX)
        {
            going = false;
        }
        float xOffset = moveSpeed * Time.deltaTime;
        if (going)
        {
            transform.position = new Vector3(transform.position.x - xOffset, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z);
        }
    }
}
