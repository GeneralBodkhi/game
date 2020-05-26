using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    
    public Transform EndPoint;

    public float speed = 10.0f;
    //public Transform StartPoint;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, EndPoint.position, Time.deltaTime*speed);
    }
}
