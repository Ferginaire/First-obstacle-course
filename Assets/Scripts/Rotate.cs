using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //Vector3 selfPos;
    
    public float speed = 5;
    public int direction = 1;
    public float bullshit = 122;
    Vector3 selfPos;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 selfPos = new Vector3(0.04f, -19.6f, 128.7f);
        Vector3 selfPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 128);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(selfPos, Vector3.up, speed * Time.deltaTime * direction);
    }
}
