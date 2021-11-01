using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_planes : MonoBehaviour
{
    public float speed = 15;
    public float direction = 1;
    //Vector3 pivPoint;
    Vector3 anus;
    // Start is called before the first frame update
    void Start()
    {
       Vector3 anus = new Vector3(0, 0.0174533f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * direction * Time.deltaTime, 0);
    }
}
