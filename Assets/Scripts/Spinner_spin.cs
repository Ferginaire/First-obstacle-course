using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner_spin : MonoBehaviour
{
    
    public Vector3 pivPoint;
    public float speed = 15;
    public float x = 0.07044983f;
    public float y = -19;
    public float z = 150.52f;


    // Start is called before the first frame update
    void Start()
    {
        pivPoint = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivPoint, Vector3.up, speed * Time.deltaTime);
    }
}
