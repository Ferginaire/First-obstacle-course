using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCircleMotion : MonoBehaviour
{
    public float moveSpeed;
    Vector3 axis = new Vector3(0, 1, 0);
    Vector3 pivPoint = new Vector3(0, -19.3f, 65);
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivPoint, axis, moveSpeed * Time.deltaTime);
        //transform.rotation = new Vector3(0, transform.rotation.y + 5, 0);
    }
}
